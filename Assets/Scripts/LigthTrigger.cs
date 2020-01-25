using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthTrigger : MonoBehaviour
{
    public bool m_endLevel = false;
    private List<Collider2D> m_colliders;

    private void Awake()
    {
        m_colliders = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_endLevel)
        {
            //Killer
            if (collision.GetComponent<PlayerController>().isLuna)
            {
                //Luna
                if (this.tag.Equals("day"))
                {
                    StartCoroutine(collision.GetComponent<PlayerController>().Die());
                }
            }
            else
            {
                //Rival
                if (this.tag.Equals("night"))
                {
                    StartCoroutine(collision.GetComponent<PlayerController>().Die());
                }
            }
        }
        else
        {
            m_colliders.Add(collision);
            //if there are alive
            if (m_colliders.Count > 1)
            {
                int player = 0;
                foreach (Collider2D c in m_colliders)
                {
                    if (c.tag.Equals("Player"))
                    {
                        if (c.GetComponent<PlayerController>().IsAlive())
                        {
                            player++;
                        }
                    }
                }

                if (player > 1)
                {
                    //Luna and Rival are together
                    StartCoroutine(collision.GetComponent<PlayerController>().NextLevel());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        m_colliders.Remove(other);
    }

    public void ChangeTag(string tag)
    {
        this.tag = tag;
    }
}
