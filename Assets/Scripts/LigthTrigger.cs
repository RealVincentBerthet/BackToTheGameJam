using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthTrigger : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>().isLuna)
        {
            //Luna
            if (this.tag.Equals("day"))
            {
                collision.GetComponent<PlayerController>().Die();
            }
        }
        else
        {
            //Rival
            if (this.tag.Equals("night"))
            {
                collision.GetComponent<PlayerController>().Die();
            }
        }
    }

    public void ChangeTag(string tag)
    {
        this.tag = tag;
    }
}
