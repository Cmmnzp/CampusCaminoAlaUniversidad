using UnityEngine;
using TMPro;

public class ExamenFinalManager : MonoBehaviour
{
    [System.Serializable]

    public class Pregunta
    {
        [TextArea(3, 5)]
        public string pregunta;

        public string opcionA;
        public string opcionB;
        public string opcionC;
        public string opcionD;

        public int respuestaCorrecta;
    }

    [Header("Preguntas")]
    public Pregunta[] preguntas;

    [Header("UI Pregunta")]
    public TextMeshProUGUI textoNumeroPregunta;

    public TextMeshProUGUI textoPregunta;

    [Header("UI Respuestas")]
    public TextMeshProUGUI textoA;

    public TextMeshProUGUI textoB;

    public TextMeshProUGUI textoC;

    public TextMeshProUGUI textoD;

    [Header("UI Puntaje")]
    public TextMeshProUGUI textoPuntaje;

    [Header("Panel Examen")]
    public GameObject panelExamen;

    [Header("Resultado Final")]
    public ResultadoFinalManager resultadoFinalManager;

    [Header("Jugador")]
    public player jugador;

    private int preguntaActual = 0;

    private int puntaje = 0;

    
    void Start()
    {
        puntaje = 0;

        if (textoPuntaje != null)
        {
            textoPuntaje.text = "0";
        }

        MostrarPregunta();
    }

   
    void MostrarPregunta()
    {
        if (preguntaActual >= preguntas.Length)
        {
            FinalizarExamen();
            return;
        }

        Pregunta p = preguntas[preguntaActual];

        textoNumeroPregunta.text =
            (preguntaActual + 1) +
            "/" +
            preguntas.Length;

        textoPregunta.text =
            p.pregunta;

        textoA.text =
            p.opcionA;

        textoB.text =
            p.opcionB;

        textoC.text =
            p.opcionC;

        textoD.text =
            p.opcionD;

        textoPuntaje.text =
            puntaje.ToString();
    }

    public void RespuestaA()
    {
        VerificarRespuesta(0);
    }

    public void RespuestaB()
    {
        VerificarRespuesta(1);
    }

    public void RespuestaC()
    {
        VerificarRespuesta(2);
    }

    public void RespuestaD()
    {
        VerificarRespuesta(3);
    }

    void VerificarRespuesta(int respuestaJugador)
    {
        if (respuestaJugador ==
            preguntas[preguntaActual].respuestaCorrecta)
        {
            puntaje += 10;
        }

        textoPuntaje.text =
            puntaje.ToString();

        preguntaActual++;

        MostrarPregunta();
    }

    
    void FinalizarExamen()
    {
       
        PlayerPrefs.SetInt(
            "PuntajeExamenFinal",
            puntaje
        );

        if (panelExamen != null)
        {
            panelExamen.SetActive(false);
        }

        if (resultadoFinalManager != null)
        {
            resultadoFinalManager
                .MostrarResultadoFinal();
        }

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }
    }
}