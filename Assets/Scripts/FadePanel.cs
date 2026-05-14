using UnityEngine;
using System.Collections;

public class FadePanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float velocidad = 2f;

    void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.unscaledDeltaTime * velocidad;

            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    public void OcultarPanel()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime * velocidad;

            yield return null;
        }

        canvasGroup.alpha = 0;

        gameObject.SetActive(false);
    }
}