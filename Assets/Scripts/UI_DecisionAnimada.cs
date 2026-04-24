using UnityEngine;
using System.Collections;

public class UI_DecisionAnimada : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public AudioSource audioSource;
    public AudioClip sonidoAparicion;

    public void Mostrar()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        if (audioSource && sonidoAparicion)
            audioSource.PlayOneShot(sonidoAparicion);

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.unscaledDeltaTime * 2f;
            yield return null;
        }
    }

    public void Ocultar()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime * 2f;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}