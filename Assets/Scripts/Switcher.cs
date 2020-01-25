using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public AstreControler m_astre;
    public GameObject m_atroGroup;
    public LigthTrigger m_light;
    private List<Collider2D> m_collide;

    void Awake()
    {
        m_collide = new List<Collider2D>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_collide.Contains(collision))
        {
            m_collide.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_collide.Remove(collision);
    }

    private void Update()
    {
        foreach(Collider2D c in m_collide)
        {
            if (c.tag.Equals("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E) && c.GetComponent<PlayerController>().IsAlive())
                {
                    Debug.Log("interact");
                    Change();
                }
            }
        }
    }

    //ACTIONS
    public void Change()
    {
        if (m_astre != null)
        {
            ChangeAstre();
        }else if(m_light != null)
        {
            ChangeLight();
        }
    }

    private void ChangeAstre()
    {
        //@TODO a mettre dans prefab de la moon
        m_astre.isRotate = true;
        string status = m_astre.GetIsSun() ? "day" : "night";
        LigthTrigger[] t = m_atroGroup.GetComponentsInChildren<LigthTrigger>();
        
        for(int i = 0; i < t.Length; i++)
        {
            t[i].tag = status;
            Debug.Log(status);
        }
 
    }

    private void ChangeLight()
    {
        //la lampe c'est soit nuit soit vide

        if (m_light.tag.Equals("night"))
        {
            m_light.tag = "empty";
        }
        else
        {
            m_light.tag = "night";
        }
    }
}
