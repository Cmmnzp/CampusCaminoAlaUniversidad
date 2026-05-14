using UnityEngine;
using System.Collections;

public class DecisionD5 : MonoBehaviour
{
    public PlayerStats stats;

    public GameObject panel;

    public GameObject panelDormir;

    public GameObject panelEstudiar;

    public player jugador;

    private bool procesando = false;

    private CanvasGroup canvasPanel;

    void Start()
    {
        if (panel != null)
        {
            canvasPanel =
                panel.GetComponent<CanvasGroup>();
        }
    }

    public void ElegirEstudiar()
    {
        Debug.Log("Abrir Estudiar");

        OcultarPanelPrincipal();

        if (panelEstudiar != null)
        {
            panelEstudiar.SetActive(true);
        }
    }

    public void ElegirDormir()
    {
        Debug.Log("Abrir Dormir");

        OcultarPanelPrincipal();

        if (panelDormir != null)
        {
            panelDormir.SetActive(true);
        }
    }

    void OcultarPanelPrincipal()
    {
        if (canvasPanel != null)
        {
            canvasPanel.alpha = 0f;

            canvasPanel.interactable = false;

            canvasPanel.blocksRaycasts = false;
        }
    }

    public void ContinuarEstudiar()
    {
        Debug.Log("CLICK ESTUDIAR");

        if (procesando)
            return;

        StartCoroutine(FinalEstudiar());
    }

    IEnumerator FinalEstudiar()
    {
        procesando = true;

        if (panelEstudiar != null)
        {
            panelEstudiar.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarConocimiento(5);

            stats.ReducirEnergia(10);

            stats.AumentarEstres(5);
        }

        yield return new WaitForSecondsRealtime(1f);

        CambiarDia("Estudio despues del parcial");
    }

    public void ContinuarDormir()
    {
        Debug.Log("CLICK DORMIR");

        if (procesando)
            return;

        StartCoroutine(FinalDormir());
    }

    IEnumerator FinalDormir()
    {
        procesando = true;

        if (panelDormir != null)
        {
            panelDormir.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarEnergia(10);

            stats.ReducirEstres(5);
        }

        yield return new WaitForSecondsRealtime(1f);

        CambiarDia("Descansaste despues del parcial");
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

        if (canvasPanel != null)
        {
            canvasPanel.alpha = 1f;

            canvasPanel.interactable = true;

            canvasPanel.blocksRaycasts = true;
        }
    }
}