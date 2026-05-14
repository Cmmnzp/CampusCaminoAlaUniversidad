using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameplayManager : MonoBehaviour
{
    public void Continuar()
    {
        Debug.Log("Continuar presionado");

        SceneManager.LoadScene("Juego");
    }
}