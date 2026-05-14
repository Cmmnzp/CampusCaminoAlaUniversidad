using UnityEngine;
using TMPro;
using System.Collections;

public class UI_DiaAnimado : MonoBehaviour
{
    [Header("Referencias")]
    public RectTransform panel;

    public TextMeshProUGUI textoDia;
    public TextMeshProUGUI textoSemana;

    public RectTransform iconoCalendario;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoCambioDia;

    [Header("Configuración")]
    public float distanciaMovimiento = 150f;
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private bool animando = false;

    void Start()
    {
        posicionInicial = panel.localPosition;
    }

    public void AnimarCambio(string dia, string semana)
    {
        StopAllCoroutines();
        StartCoroutine(TransicionCalendario(dia, semana));
    }

    IEnumerator TransicionCalendario(string nuevoDia, string nuevaSemana)
    {
        animando = true;

        Vector3 arriba = posicionInicial + Vector3.up * distanciaMovimiento;
        Vector3 abajo = posicionInicial - Vector3.up * distanciaMovimiento;

        // 🔊 sonido
        if (audioSource && sonidoCambioDia)
            audioSource.PlayOneShot(sonidoCambioDia);

        // 🔵 SUBE PANEL ACTUAL
        for (float t = 0; t < 1; t += Time.deltaTime * velocidad)
        {
            panel.localPosition = Vector3.Lerp(posicionInicial, arriba, t);
            yield return null;
        }

        // 🔄 CAMBIO DE TEXTO
        textoDia.text = nuevoDia;
        textoSemana.text = nuevaSemana;

        // colocar panel abajo
        panel.localPosition = abajo;

        // 🔥 RESET ICONO (ANTES DE ENTRAR)
        iconoCalendario.localScale = Vector3.zero;
        iconoCalendario.localRotation = Quaternion.Euler(0, 0, -30f);

        // 🟢 ENTRADA CON EASE
        float t2 = 0;
        while (t2 < 1)
        {
            t2 += Time.deltaTime * velocidad;

            float ease = Mathf.SmoothStep(0, 1, t2);

            panel.localPosition = Vector3.Lerp(abajo, posicionInicial, ease);

            // animación icono
            iconoCalendario.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ease);
            iconoCalendario.localRotation = Quaternion.Lerp(
                Quaternion.Euler(0, 0, -30f),
                Quaternion.identity,
                ease
            );

            yield return null;
        }

        // 💥 REBOTE PANEL
        yield return StartCoroutine(RebotePanel());

        // 💥 REBOTE ICONO
        iconoCalendario.localScale = Vector3.one * 1.1f;
        yield return new WaitForSeconds(0.08f);
        iconoCalendario.localScale = Vector3.one;

        animando = false;
    }

    IEnumerator RebotePanel()
    {
        Vector3 escalaOriginal = panel.localScale;

        panel.localScale = escalaOriginal * 1.05f;
        yield return new WaitForSeconds(0.08f);

        panel.localScale = escalaOriginal;
    }

    void Update()
    {
        if (!animando)
        {
            // 💫 latido panel
            float scalePanel = 1 + Mathf.Sin(Time.time * 3f) * 0.01f;
            panel.localScale = Vector3.one * scalePanel;

            // 💫 latido icono
            float scaleIcono = 1 + Mathf.Sin(Time.time * 2f) * 0.02f;
            iconoCalendario.localScale = Vector3.one * scaleIcono;
        }
    }
}