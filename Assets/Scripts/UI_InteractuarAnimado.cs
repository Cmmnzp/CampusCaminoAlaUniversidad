using UnityEngine;
using System.Collections;

public class UI_InteractuarAnimado : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public RectTransform rect;

    public AudioSource audioSource;

    public AudioClip sonidoAparicion;

    private bool animando = false;

    void OnEnable()
    {
        StopAllCoroutines();

        StartCoroutine(Aparecer());
    }

    IEnumerator Aparecer()
    {
        animando = true;

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
        }

        if (rect != null)
        {
            rect.localScale = Vector3.zero;
        }

        if (audioSource != null && sonidoAparicion != null)
        {
            audioSource.PlayOneShot(sonidoAparicion);
        }

        while (canvasGroup != null &&
               canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 4f;

            if (rect != null)
            {
                rect.localScale =
                    Vector3.Lerp(
                        rect.localScale,
                        Vector3.one,
                        Time.deltaTime * 10f
                    );
            }

            yield return null;
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1;
        }

        if (rect != null)
        {
            rect.localScale = Vector3.one;
        }

        animando = false;
    }

    void Update()
    {
        if (!animando && gameObject.activeSelf)
        {
            if (rect != null)
            {
                float scale =
                    1 + Mathf.Sin(Time.time * 3f) * 0.05f;

                rect.localScale =
                    new Vector3(scale, scale, scale);
            }
        }
    }

    public void Ocultar()
    {
        StopAllCoroutines();

        animando = false;

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
        }

        if (rect != null)
        {
            rect.localScale = Vector3.zero;
        }

        gameObject.SetActive(false);
    }

    public void OcultarAnimado()
    {
        StopAllCoroutines();

        StartCoroutine(Desaparecer());
    }

    IEnumerator Desaparecer()
    {
        animando = true;

        while (canvasGroup != null &&
               canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 4f;

            if (rect != null)
            {
                rect.localScale =
                    Vector3.Lerp(
                        rect.localScale,
                        Vector3.zero,
                        Time.deltaTime * 10f
                    );
            }

            yield return null;
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
        }

        animando = false;

        gameObject.SetActive(false);
    }
}