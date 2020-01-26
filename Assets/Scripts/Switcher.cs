using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Switcher : MonoBehaviour
{
    public AstreControler m_astre;
    public LigthTrigger m_light;
    public Light2D m_light2d;
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
        collision.GetComponent<PlayerController>().showHelpBulb(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_collide.Remove(collision);
        collision.GetComponent<PlayerController>().showHelpBulb(false); 
    }

    private void Update()
    {
        foreach(Collider2D c in m_collide)
        {
            if (c.tag.Equals("Player") && c.GetComponent<PlayerController>().IsAlive())
            {
                if(Input.GetKeyDown(KeyCode.E) && c.GetComponent<PlayerController>().isLuna)
                {
                    Debug.Log("interact");
                    Change();
                }
                else if (Input.GetKeyDown(KeyCode.RightControl) && !c.GetComponent<PlayerController>().isLuna)
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
        this.GetComponent<AudioSource>().Play();
        if (m_astre != null)
        {
            m_astre.isRotate = true;
        }else if(m_light != null)
        {
            ChangeLight();
        }
    }
    private void ChangeLight()
    {
        //la lampe c'est soit nuit soit vide
        if (m_light.tag.Equals("night"))
        {
            m_light.tag = "empty";
            m_light2d.intensity = 1;
        }
        else
        {
            m_light.tag = "night";
            m_light2d.intensity = 0;
        }
    }
}
