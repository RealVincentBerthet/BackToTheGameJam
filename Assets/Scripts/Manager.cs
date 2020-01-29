using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    private string test = "toto";
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
