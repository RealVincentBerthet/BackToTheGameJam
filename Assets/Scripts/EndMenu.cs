using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI m_timer;
    public bool hasCredits = true;
    private void Start()
    {
        if (m_timer != null)
        {
            float startTime = Time.time;
            if (PlayerPrefs.HasKey("startTime"))
            {
                startTime = PlayerPrefs.GetFloat("startTime");
            }
            float time_elapsed = Time.time - startTime;

            string minutes = Mathf.Floor(time_elapsed / 60).ToString("00");
            string seconds = (time_elapsed % 60).ToString("00");

            m_timer.text = minutes + ":" + seconds;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (hasCredits)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
