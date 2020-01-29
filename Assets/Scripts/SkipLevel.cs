using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
