using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    private bool m_alive = true;
    float horizontalMove = 0f;
    bool jump = false;

    public bool isLuna = false;

    // Update is called once per frame
    void Update()
    {
        #region Action

        #endregion
        #region Movement
        horizontalMove = 0f;
        if(controller)
        if (isLuna)
        {
    
            if (Input.GetKey(KeyCode.Z))
            {
                jump = true;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                horizontalMove = -1*runSpeed/(controller.IsGrounded() ? 1 : 2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                    horizontalMove = runSpeed / (controller.IsGrounded() ? 1 : 2);
                }
        }
        else
        {
            //Rival code
            if (Input.GetKey(KeyCode.UpArrow))
            {
                jump = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                 horizontalMove = -1 * runSpeed / (controller.IsGrounded() ? 1 : 2);
             }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontalMove = runSpeed / (controller.IsGrounded() ? 1 : 2);
             }
        }
        #endregion
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public IEnumerator Die()
    {
        m_alive = false;
        if (isLuna)
        {
            Debug.Log("Luna is dead");
        }
        else
        {
            Debug.Log("Rival is dead");
        }
        yield return null;
    }


    public bool IsAlive()
    {
        return m_alive;
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("GG ! Next Level");
    }
}


