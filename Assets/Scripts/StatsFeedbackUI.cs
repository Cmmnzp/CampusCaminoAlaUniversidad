using UnityEngine;
using TMPro;
using System.Collections;

public class StatsFeedbackUI : MonoBehaviour
{
    public static StatsFeedbackUI instancia;

    [Header("Prefab")]
    public GameObject textoPrefab;
    public Transform contenedor;

    [Header("Configuración")]
    public float velocidadSubida = 1.5f;
    public float tiempoVisible = 1.2f;
    public float velocidadFade = 2f;

    [Header("Efectos")]
    public float escalaInicial = 1.3f;

    // 🔥 stack vertical
    private float offsetY = 0f;
    private float separacion = 30f;

    void Awake()
    {
        instancia = this;
    }

    public void Mostrar(string mensaje, Color color)
    {
        GameObject nuevo = Instantiate(textoPrefab, contenedor);

        TextMeshProUGUI texto = nuevo.GetComponent<TextMeshProUGUI>();

        texto.text = mensaje;
        texto.color = color;

        nuevo.SetActive(true);

        // 🟢 POSICIÓN ORDENADA (STACK)
        Vector3 pos = texto.transform.localPosition;
        pos.y += offsetY;
        texto.transform.localPosition = pos;

        offsetY += separacion;

        StartCoroutine(Animar(texto));
    }

    IEnumerator Animar(TextMeshProUGUI texto)
    {
        Vector3 inicio = texto.transform.localPosition;
        Vector3 fin = inicio + Vector3.up * 80f;

        float t = 0;

        // 💥 POP IN + SUBIDA
        texto.transform.localScale = Vector3.one * escalaInicial;

        while (t < 1)
        {
            t += Time.deltaTime * velocidadSubida;

            float ease = Mathf.SmoothStep(0, 1, t);

            texto.transform.localPosition = Vector3.Lerp(inicio, fin, ease);

            float escala = Mathf.Lerp(escalaInicial, 1f, ease);
            texto.transform.localScale = Vector3.one * escala;

            yield return null;
        }

        // ⏸️ TIEMPO VISIBLE
        yield return new WaitForSeconds(tiempoVisible);

        // 🌫️ FADE + SUBIDA SUAVE
        float fade = 1;

        while (fade > 0)
        {
            fade -= Time.deltaTime * velocidadFade;

            texto.color = new Color(
                texto.color.r,
                texto.color.g,
                texto.color.b,
                fade
            );

            texto.transform.localPosition += Vector3.up * Time.deltaTime * 20f;

            yield return null;
        }

        // 🔄 LIBERAR ESPACIO EN STACK
        offsetY -= separacion;

        Destroy(texto.gameObject);
    }
}