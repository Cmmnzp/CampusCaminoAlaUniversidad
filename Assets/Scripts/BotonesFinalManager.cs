using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesFinalManager : MonoBehaviour
{
    [Header("Paneles")]

    public GameObject panelCreditos;

  
    public void ReiniciarJuego()
    {
       

        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }

    public void AbrirCreditos()
    {
        if (panelCreditos != null)
        {
            panelCreditos.SetActive(true);
        }
    }

    public void CerrarCreditos()
    {
        if (panelCreditos != null)
        {
            panelCreditos.SetActive(false);
        }
    }
}