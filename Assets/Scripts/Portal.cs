using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private List<Collider2D> m_colliders;
    public Animator m_animator;
    private void Awake()
    {
        m_colliders = new List<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!m_colliders.Contains(collision)) m_colliders.Add(collision);
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
                foreach (Collider2D c in m_colliders)
                {
                    if (c.tag.Equals("Player"))
                    {
                        c.GetComponent<PlayerController>().runSpeed = 0;
                        m_animator.gameObject.SetActive(true);
                    }
                }
                StartCoroutine(collision.GetComponent<PlayerController>().NextLevel());
            }
        }
        
    }
}
