using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PuzzleProgramacion : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textoResultado;
    public CanvasGroup canvasGroup;

    [Header("Jugador")]
    public player jugador;
    public PlayerStats stats;

    [Header("Colores")]
    public Color colorCorrecto = Color.green;
    public Color colorIncorrecto = Color.red;
    public Color colorNormal = Color.white;

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoError;

    private List<string> ordenActual = new List<string>();
    private string[] ordenCorrecto = { "Leer", "Procesar", "Mostrar", "Fin" };

    private bool puzzleCompletado = false;

    void OnEnable()
    {
        Reiniciar();
        puzzleCompletado = false;

        if (jugador != null)
            jugador.puedeMoverse = false;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 2f;
            yield return null;
        }
    }

    public void AgregarBloque(string bloque)
    {
        if (puzzleCompletado) return;

        ordenActual.Add(bloque);
        textoResultado.text = string.Join(" → ", ordenActual);
        textoResultado.color = colorNormal;
    }

    public void Verificar()
    {
        if (puzzleCompletado) return;

        if (ordenActual.Count != ordenCorrecto.Length)
        {
            Error();
            textoResultado.text = "Orden incompleto";
            return;
        }

        for (int i = 0; i < ordenCorrecto.Length; i++)
        {
            if (ordenActual[i] != ordenCorrecto[i])
            {
                Error();
                textoResultado.text = "Orden incorrecto";
                return;
            }
        }

        textoResultado.text = "¡Correcto!";
        textoResultado.color = colorCorrecto;

        puzzleCompletado = true;

        if (audioSource && sonidoCorrecto)
            audioSource.PlayOneShot(sonidoCorrecto);

        if (stats != null)
        {
            stats.AumentarConocimiento(30);
            stats.ReducirEstres(10);
        }

        Invoke("ActivarLuis", 1.5f);

        StartCoroutine(FadeOut());
    }

    void ActivarLuis()
    {
        Debug.Log("🔥 Activando NPC Mateo para decision");

        if (DayManager.instancia != null && DayManager.instancia.npcLuis != null)
        {
            DayManager.instancia.npcLuis.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.AsignarMision("Decide como estudiar con Mateo");
        }
    }

    void Error()
    {
        textoResultado.color = colorIncorrecto;

        if (audioSource && sonidoError)
            audioSource.PlayOneShot(sonidoError);

        if (stats != null)
        {
            if (stats.conocimiento > 0)
                stats.ReducirConocimiento(15);

            stats.AumentarEstres(10);
        }
    }

    void CambiarDia()
    {
        if (DayManager.instancia != null)
        {
            Debug.Log("🔥 Pasando a Día 3");
            DayManager.instancia.SiguienteDia();
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.ActualizarMisionPorDia();
        }
    }

    public void Reiniciar()
    {
        ordenActual.Clear();
        textoResultado.text = "(Selecciona los bloques)";
        textoResultado.color = colorNormal;
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2f;
            yield return null;
        }

        if (jugador != null)
            jugador.puedeMoverse = true;

        gameObject.SetActive(false);
    }
}