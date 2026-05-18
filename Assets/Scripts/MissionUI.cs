using UnityEngine;
using TMPro;
using System.Collections;

public class MissionUI : MonoBehaviour
{
    public static MissionUI instancia;

    public TextMeshProUGUI textoMision;
    public CanvasGroup canvasGroup;
    public AudioSource sonidoMision;

    private bool primeraMision = true;

    void Awake()
    {
        instancia = this;
    }

    public void ActualizarMision(string nuevaMision)
    {
        StopAllCoroutines();
        StartCoroutine(MostrarMision(nuevaMision));

        if (sonidoMision != null)
            sonidoMision.Play();
    }

    IEnumerator MostrarMision(string nuevaMision)
    {
        if (!primeraMision)
        {
            textoMision.text = "✔ Misión completada";
            yield return new WaitForSeconds(1.5f);
        }

        primeraMision = false;

        for (float i = 1; i >= 0; i -= Time.deltaTime * 2)
        {
            canvasGroup.alpha = i;
            yield return null;
        }

        textoMision.text = "Misión: " + nuevaMision;

        for (float i = 0; i <= 1; i += Time.deltaTime * 2)
        {
            canvasGroup.alpha = i;
            yield return null;
        }
    }
}