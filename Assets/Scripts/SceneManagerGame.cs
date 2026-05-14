using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;

    public void StartGame()
    {
        Debug.Log("Boton Play Presionado ...");

        SceneManager.LoadScene("IntroGameplay");
    }

    public void OpenOptions()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Juego cerrado");
        Application.Quit();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}