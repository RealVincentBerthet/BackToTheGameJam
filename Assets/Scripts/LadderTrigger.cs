using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    private bool onLadder = false;
    private bool isClimbing;
    private List<Collider2D> m_collide;

    public void Awake()
    {
        m_collide = new List<Collider2D>();
    }

    void Update()
    {
        isClimbing = Input.GetKey(KeyCode.E);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_collide.Contains(collision))
        {
            m_collide.Add(collision);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        m_collide.Remove(collision);
    }
}
