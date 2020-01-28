using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Switcher : MonoBehaviour
{
    public AstreControler m_astre;
    public List<LigthTrigger> l_light;
    public List<Light2D> l_light2D;
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
                    Change();
                }
                else if (Input.GetKeyDown(KeyCode.I) && !c.GetComponent<PlayerController>().isLuna)
                {
                    Change();
                }
            }
        }
    }

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
        //Artificial light is set to null or night
        if (l_light != null && l_light2D != null)
        {
            for(int i = 0; i < l_light2D.Count; i++)
            {
                Light2D l2d = l_light2D[i];
                LigthTrigger ltrigger = l_light[i];
                if (ltrigger.tag.Equals("night"))
                {
                    ltrigger.tag = "empty";
                    l2d.intensity = 1;
                }
                else
                {
                    ltrigger.tag = "night";
                    l2d.intensity = 0;
                }
            }
        }
        else
        {
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
}
