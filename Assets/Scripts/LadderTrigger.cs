using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
        {
            player.SetOnLadder(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.SetOnLadder(false);
        }
    }
    
}
