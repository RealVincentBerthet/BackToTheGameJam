using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
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

    public void ChangeTag(string tag)
    {
        this.tag = tag;
    }
}
