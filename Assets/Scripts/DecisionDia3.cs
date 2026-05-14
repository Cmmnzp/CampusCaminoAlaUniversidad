using UnityEngine;
using System.Collections;

public class DecisionDia3 : MonoBehaviour
{
    public PlayerStats stats;

    public GameObject panel;

    public GameObject panelBiblioteca;

    public GameObject panelCafeteria;

    public player jugador;

    private bool procesando = false;

    public void ElegirBiblioteca()
    {
        Debug.Log("Abrir Biblioteca");

        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (panelBiblioteca != null)
        {
            panelBiblioteca.SetActive(true);
        }
    }

    public void ElegirCafeteria()
    {
        Debug.Log("Abrir Cafeteria");

        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (panelCafeteria != null)
        {
            panelCafeteria.SetActive(true);
        }
    }

    public void ContinuarBiblioteca()
    {
        Debug.Log("CLICK BIBLIOTECA");

        if (procesando)
            return;

        StartCoroutine(FinalBiblioteca());
    }

    IEnumerator FinalBiblioteca()
    {
        procesando = true;

        if (panelBiblioteca != null)
        {
            panelBiblioteca.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarConocimiento(25);
            stats.ReducirEstres(10);
            stats.ReducirEnergia(15);
        }

        yield return new WaitForSecondsRealtime(1f);

        CambiarDia("Biblioteca");
    }

    public void ContinuarCafeteria()
    {
        Debug.Log("CLICK CAFETERIA");

        if (procesando)
            return;

        StartCoroutine(FinalCafeteria());
    }

    IEnumerator FinalCafeteria()
    {
        procesando = true;

        if (panelCafeteria != null)
        {
            panelCafeteria.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarRelaciones(20);
            stats.ReducirEstres(15);
            stats.AumentarEnergia(10);
        }

        yield return new WaitForSecondsRealtime(1f);

        CambiarDia("Cafeteria");
    }

    void CambiarDia(string decision)
    {
        Debug.Log("CAMBIANDO DIA");

        Time.timeScale = 1f;

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        if (DayEndManager.instancia != null)
        {
            DayEndManager.instancia.TerminarDia(decision);
        }
    }

    void OnEnable()
    {
        procesando = false;

        Time.timeScale = 0f;

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }
    }
}