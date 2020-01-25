using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

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
        if (isLuna)
        {
    
            if (Input.GetKey(KeyCode.Z))
            {
                jump = true;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                horizontalMove = -1*runSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                horizontalMove =  runSpeed;
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
                horizontalMove = -1 * runSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontalMove = runSpeed;
            }
        }
        #endregion
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void Die()
    {
        if (isLuna)
        {
            Debug.Log("Luna is dead");
        }
        else
        {
            Debug.Log("Rival is dead");
        }
    }
}
