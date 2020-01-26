
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    private bool m_alive = true;
    float horizontalMove = 0f;
    bool jump = false;
    public Animator animator;
    public PlayerController otherPlayer;
    public SpriteRenderer helpBulb;

    public bool isLuna = false;

    public void Awake()
    {

        helpBulb.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        #region Action

        #endregion
        #region Movement
        horizontalMove = 0f;
        if(!m_alive)
        {
            horizontalMove = 0;
            return;
        }
        if (controller && m_alive)
        {
            if (isLuna)
            {

                if (Input.GetKey(KeyCode.Z))
                {
                    jump = true;
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    horizontalMove = -1 * runSpeed / (controller.IsGrounded() ? 1 : 2);
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
            GameObject.Find("LunadDead").SetActive(true);
        }
        else
        {
            Debug.Log("Rival is dead");
            GameObject.Find("HeliosDead").SetActive(true);
        }
        animator.SetTrigger("Death");
        GameObject.Find("FXPanel").GetComponent<Animator>().SetTrigger("end");
        yield return null;
    }


    public bool IsAlive()
    {
        return m_alive;
    }

    public IEnumerator NextLevel()
    {
        Debug.Log("GG ! Next Level");
        GameObject.Find("FXPanel").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(2.0f);
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }


    }

    public void showHelpBulb(bool visible)
    {
        helpBulb.enabled = visible;
    }
}
