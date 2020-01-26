using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button m_playButton;
    public Button m_rulesButton;
    public Button m_optionsButton;
    public Button m_creditsButton;
    public Button m_quitButton;
    public GameObject m_menuItems;
    public GameObject m_rulesMenu;
    public GameObject m_optionsMenu;
    public GameObject m_creditsMenu;
    public Button m_back;

    public void Awake()
    {
        /*
        m_playButton.onClick.AddListener(delegate { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); });
        m_rulesButton.onClick.AddListener(delegate { m_menuItems.SetActive(false); m_rulesMenu.SetActive(true); });
        m_optionsButton.onClick.AddListener(delegate { m_menuItems.SetActive(false); m_optionsMenu.SetActive(true); });
        m_creditsButton.onClick.AddListener(delegate { m_menuItems.SetActive(false); m_creditsMenu.SetActive(true); });
        m_quitButton.onClick.AddListener(delegate { Application.Quit(); });
        m_back.onClick.AddListener(delegate { m_menuItems.SetActive(true);m_rulesMenu.SetActive(false);m_optionsMenu.SetActive(false);m_creditsMenu.SetActive(false); m_back.gameObject.SetActive(false); m_quitButton.gameObject.SetActive(true); });
        */
    }

    public void Update()
    {
        // m_quitButton.gameObject.SetActive(!m_back.isActiveAndEnabled);
        // m_back.gameObject.SetActive(!m_quitButton.isActiveAndEnabled);
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerPrefs.SetFloat("startTime",Time.time);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
