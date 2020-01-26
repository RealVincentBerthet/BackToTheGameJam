using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI m_timer;

    private void Start()
    {
        float startTime = Time.time;
        if (PlayerPrefs.HasKey("startTime"))
        {
            startTime = PlayerPrefs.GetFloat("startTime");
        }
        float time_elapsed = Time.time- startTime;

        string minutes = Mathf.Floor(time_elapsed / 60).ToString("00");
        string seconds = (time_elapsed % 60).ToString("00");


        m_timer.text = minutes + ":" + seconds;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
