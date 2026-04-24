using UnityEngine;
using System.Collections;

public class UIFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float velocidad = 2f;

    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * velocidad;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}