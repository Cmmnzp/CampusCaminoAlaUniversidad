using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    void Start()
    {
        Invoke("IrAlMenu", 5f);
    }

    void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}