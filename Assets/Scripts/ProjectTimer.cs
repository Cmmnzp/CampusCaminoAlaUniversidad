using UnityEngine;
using TMPro;

public class ProjectTimer : MonoBehaviour
{
    public float tiempoRestante = 120f;

    public TextMeshProUGUI textoTiempo;

    public AlgorithmValidator validator;

    private bool tiempoActivo = false;

    private bool terminado = false;

    void Start()
    {
        MostrarTiempo();
    }

    void Update()
    {
        if (!tiempoActivo || terminado)
            return;

        tiempoRestante -= Time.unscaledDeltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;

            terminado = true;

            textoTiempo.text = "00:00";

            if (validator != null)
            {
                validator.resultadoTexto.text =
                    "TIEMPO AGOTADO";

                validator.resultadoTexto.color =
                    Color.red;
            }
        }

        MostrarTiempo();
    }

    void MostrarTiempo()
    {
        int minutos =
            Mathf.FloorToInt(tiempoRestante / 60);

        int segundos =
            Mathf.FloorToInt(tiempoRestante % 60);

        textoTiempo.text =
            string.Format(
                "{0:00}:{1:00}",
                minutos,
                segundos
            );

        if (tiempoRestante <= 20)
        {
            textoTiempo.color = Color.red;
        }
        else
        {
            textoTiempo.color = Color.white;
        }
    }

    public void IniciarTimer()
    {
        tiempoActivo = true;
    }

    public void DetenerTimer()
    {
        tiempoActivo = false;
    }

    public void ReiniciarTimer()
    {
        tiempoRestante = 120f;

        terminado = false;

        MostrarTiempo();
    }
}