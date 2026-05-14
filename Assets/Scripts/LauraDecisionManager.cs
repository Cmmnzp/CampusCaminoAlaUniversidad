using UnityEngine;
using System.Collections;

public class LauraDecisionManager : MonoBehaviour
{
    [Header("Panel Principal")]
    public GameObject panelDecision;

    [Header("Paneles Narrativos")]
    public GameObject panelBiblioteca;

    public GameObject panelCafeteria;

    [Header("Jugador")]
    public player jugador;

    public PlayerStats stats;

    private bool procesando = false;

    void Start()
    {
        if (panelDecision != null)
            panelDecision.SetActive(false);

        if (panelBiblioteca != null)
            panelBiblioteca.SetActive(false);

        if (panelCafeteria != null)
            panelCafeteria.SetActive(false);
    }

    public void AbrirDecision()
    {
        if (panelDecision != null)
        {
            panelDecision.SetActive(true);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        Time.timeScale = 0f;
    }

    public void ElegirBiblioteca()
    {
        if (panelDecision != null)
        {
            panelDecision.SetActive(false);
        }

        if (panelBiblioteca != null)
        {
            panelBiblioteca.SetActive(true);
        }
    }

    public void ElegirCafeteria()
    {
        if (panelDecision != null)
        {
            panelDecision.SetActive(false);
        }

        if (panelCafeteria != null)
        {
            panelCafeteria.SetActive(true);
        }
    }

    public void ContinuarBiblioteca()
    {
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

        FinalizarDia("Biblioteca");
    }

    public void ContinuarCafeteria()
    {
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

        FinalizarDia("Cafeteria");
    }

    void FinalizarDia(string decision)
    {
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
}