
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public AudioSource[] tab_audio;
    public float runSpeed = 40f;
    private bool m_alive = true;
    float horizontalMove = 0f;
    bool jump = false;
    public Animator animator;
    public PlayerController otherPlayer;
    public SpriteRenderer helpBulb;
    public GameObject m_deadScreen;
    public bool isLuna = false;

    public void Awake()
    {
        helpBulb.enabled = false;
        m_deadScreen.SetActive(false);
    }

    void Update()
    {
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
        if (IsAlive())
        {
            m_alive = false;
            int random = Random.Range(0, tab_audio.Length);
            tab_audio[random].Play();

            animator.SetTrigger("Death");
            yield return new WaitForSeconds(1.0f);
            m_deadScreen.SetActive(true);
            StartCoroutine(RetryLevel());
        }
    }

    public bool IsAlive()
    {
        return m_alive;
    }

    public IEnumerator NextLevel()
    {
        //GameObject.Find("FXPanel").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public IEnumerator RetryLevel()
    {
        //GameObject.Find("FXPanel").GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void showHelpBulb(bool visible)
    {
        helpBulb.enabled = visible;
    }
}
