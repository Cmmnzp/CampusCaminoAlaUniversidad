using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public bool llaveRecogida = false;
    public bool llaveEntregada = false;

    bool juegoGanado = false;

    void Update()
    {
        if (!juegoGanado && score >= 100 && llaveRecogida && llaveEntregada)
        {
            juegoGanado = true;

            StartCoroutine(ReiniciarJuego());
        }
    }

    IEnumerator ReiniciarJuego()
    {
        yield return new WaitForSeconds(6f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}