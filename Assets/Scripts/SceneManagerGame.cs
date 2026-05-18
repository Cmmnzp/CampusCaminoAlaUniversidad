using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    [Header("PANELS")]
    public GameObject menuPanel;

    public GameObject optionsPanel;

    public GameObject loginPanel;

    public GameObject registerPanel;

    [Header("MENSAJE")]
    public GameObject mensajeRegistroExitoso;

    public void StartGame()
    {
        Debug.Log("BOTON PLAY");

        SceneManager.LoadScene(
            "IntroGameplay"
        );
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

    public void OpenLogin()
    {
        menuPanel.SetActive(false);

        loginPanel.SetActive(true);
    }

    public void CloseLogin()
    {
        loginPanel.SetActive(false);

        menuPanel.SetActive(true);
    }

    public void OpenRegister()
    {
        menuPanel.SetActive(false);

        registerPanel.SetActive(true);
    }

    public void CloseRegister()
    {
        registerPanel.SetActive(false);

        menuPanel.SetActive(true);
    }

    public void RegistroExitoso()
    {
        registerPanel.SetActive(false);

        loginPanel.SetActive(true);

        mensajeRegistroExitoso.SetActive(true);

        StartCoroutine(
            OcultarMensaje()
        );
    }

    IEnumerator OcultarMensaje()
    {
        yield return new WaitForSeconds(3f);

        mensajeRegistroExitoso.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("JUEGO CERRADO");

        Application.Quit();
    }

    void Start()
    {
        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;
    }
}