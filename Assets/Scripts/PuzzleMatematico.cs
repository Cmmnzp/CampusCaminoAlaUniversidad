using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PuzzleMatematico : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textoResultado;

    public TextMeshProUGUI textoFeedback;

    public CanvasGroup canvasGroup;

    public RectTransform panelCentral;

    [Header("Jugador")]
    public player jugador;

    public PlayerStats stats;

    [Header("Decision Dia 3")]
    public GameObject panelDecision;

    [Header("Audio")]
    public AudioSource audioSource;

    public AudioClip sonidoCorrecto;

    public AudioClip sonidoIncorrecto;

    private bool resuelto = false;

    public void Responder(int opcion)
    {
        if (resuelto)
            return;

        if (opcion == 32)
        {
            Correcto();
        }
        else
        {
            Incorrecto();
        }
    }

    
    void Correcto()
    {
        textoResultado.text = "Correcto";

        textoResultado.color = Color.green;

        resuelto = true;

        if (stats != null)
        {
            stats.AumentarConocimiento(25);

            stats.ReducirEstres(10);
        }

        if (audioSource != null &&
            sonidoCorrecto != null)
        {
            audioSource.PlayOneShot(sonidoCorrecto);
        }

        if (textoFeedback != null)
        {
            textoFeedback.text =
                "+25 Conocimiento\n-10 Estres";

            textoFeedback.gameObject.SetActive(true);

            StartCoroutine(AnimarFeedback());
        }

        Invoke(nameof(Finalizar), 1.5f);
    }

    
    void Incorrecto()
    {
        textoResultado.text = "Incorrecto";

        textoResultado.color = Color.red;

        if (stats != null)
        {
            stats.ReducirConocimiento(20);

            stats.AumentarEstres(30);
        }

        if (audioSource != null &&
            sonidoIncorrecto != null)
        {
            audioSource.PlayOneShot(sonidoIncorrecto);
        }
    }

    
    void Finalizar()
    {
        Invoke(nameof(CerrarPuzzle), 1.5f);
    }

    void CerrarPuzzle()
    {
        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        gameObject.SetActive(false);

        if (panelDecision != null)
        {
            panelDecision.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(3);

            MissionManager.instancia.AsignarMision(
                "Toma una decision: Biblioteca o Cafeteria"
            );
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Decision Dia 3 abierta");
    }

    void OnEnable()
    {
        
        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        resuelto = false;

        if (textoResultado != null)
        {
            textoResultado.text = "";

            textoResultado.color = Color.white;
        }

        if (textoFeedback != null)
        {
            textoFeedback.gameObject.SetActive(false);
        }

        StartCoroutine(AnimarEntrada());
    }

    IEnumerator AnimarEntrada()
    {
        float t = 0;

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
        }

        if (panelCentral != null)
        {
            panelCentral.localScale = Vector3.zero;
        }

        while (t < 1)
        {
            t += Time.deltaTime * 4f;

            if (canvasGroup != null)
            {
                canvasGroup.alpha = t;
            }

            if (panelCentral != null)
            {
                panelCentral.localScale =
                    Vector3.Lerp(
                        Vector3.zero,
                        Vector3.one,
                        t
                    );
            }

            yield return null;
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1;
        }

        if (panelCentral != null)
        {
            panelCentral.localScale = Vector3.one;
        }
    }

    IEnumerator AnimarFeedback()
    {
        float t = 0;

        Vector3 inicio =
            textoFeedback.transform.localPosition;

        Vector3 fin =
            inicio + Vector3.up * 60f;

        Color color = textoFeedback.color;

        while (t < 1)
        {
            t += Time.deltaTime * 2f;

            textoFeedback.transform.localPosition =
                Vector3.Lerp(inicio, fin, t);

            textoFeedback.color =
                new Color(
                    color.r,
                    color.g,
                    color.b,
                    1 - t
                );

            yield return null;
        }

        textoFeedback.gameObject.SetActive(false);

        textoFeedback.transform.localPosition =
            inicio;

        textoFeedback.color = color;
    }
}