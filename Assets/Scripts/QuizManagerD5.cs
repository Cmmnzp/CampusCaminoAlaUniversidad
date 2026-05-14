using UnityEngine;
using TMPro;

public class QuizManagerD5 : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textoPregunta;

    public TextMeshProUGUI textoProgreso;

    public TextMeshProUGUI textoResultado;

    public TextMeshProUGUI textoBotonA;

    public TextMeshProUGUI textoBotonB;

    public TextMeshProUGUI textoBotonC;

    public TextMeshProUGUI textoBotonD;

    [Header("Jugador")]
    public player jugador;

    public PlayerStats stats;

    [Header("Decision")]
    public GameObject panelDecisionD5;

    private int preguntaActual = 0;

    private int respuestasCorrectas = 0;

    string[] preguntas =
    {
        "¿Que describe mejor un algoritmo?",

        "¿Cual es la funcion de una variable?",

        "¿Para que se utiliza una condicion IF?",

        "¿Que permite hacer un LOOP?",

        "¿Cual es la utilidad principal de una lista?"
    };

    string[,] respuestas =
    {
        {
            "Conjunto de pasos ordenados para resolver un problema",
            "Un sistema para dibujar personajes",
            "Una herramienta para crear sonidos",
            "Un error dentro del programa"
        },

        {
            "Cerrar un programa",
            "Mover objetos automaticamente",
            "Guardar informacion que puede cambiar",
            "Eliminar instrucciones"
        },

        {
            "Crear animaciones del juego",
            "Tomar decisiones dependiendo de una condicion",
            "Aumentar velocidad del computador",
            "Repetir codigo infinitamente"
        },

        {
            "Guardar imagenes del sistema",
            "Crear mapas automaticamente",
            "Controlar el volumen del juego",
            "Repetir instrucciones varias veces"
        },

        {
            "Almacenar varios elementos organizados",
            "Cambiar colores del programa",
            "Mover al personaje principal",
            "Crear efectos de sonido"
        }
    };

    int[] correctas =
    {
        0,
        2,
        1,
        3,
        0
    };

    void Start()
    {
        MostrarPregunta();

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (textoResultado != null)
        {
            textoResultado.text = "";
        }
    }

    void MostrarPregunta()
    {
        textoPregunta.text =
            preguntas[preguntaActual];

        textoProgreso.text =
            "Pregunta " +
            (preguntaActual + 1) +
            "/5";

        textoBotonA.text =
            respuestas[preguntaActual, 0];

        textoBotonB.text =
            respuestas[preguntaActual, 1];

        textoBotonC.text =
            respuestas[preguntaActual, 2];

        textoBotonD.text =
            respuestas[preguntaActual, 3];
    }

    public void Responder(int opcion)
    {
        if (opcion == correctas[preguntaActual])
        {
            respuestasCorrectas++;

            if (stats != null)
            {
                stats.AumentarConocimiento(3);
            }
        }
        else
        {
            if (stats != null)
            {
                stats.AumentarEstres(2);
            }
        }

        preguntaActual++;

        if (preguntaActual >= preguntas.Length)
        {
            FinalizarParcial();
        }
        else
        {
            MostrarPregunta();
        }
    }

    void FinalizarParcial()
    {
        textoResultado.text =
            "Resultado Final: " +
            respuestasCorrectas +
            "/5";

        if (respuestasCorrectas >= 4)
        {
            textoResultado.text +=
                "\nExcelente rendimiento";
        }
        else if (respuestasCorrectas >= 2)
        {
            textoResultado.text +=
                "\nBuen intento";
        }
        else
        {
            textoResultado.text +=
                "\nDebes seguir estudiando";
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(3);

            MissionManager.instancia.AsignarMision(
                "Decide si estudiar o descansar"
            );
        }

        Invoke(nameof(AbrirDecision), 4f);
    }

    void AbrirDecision()
    {
        gameObject.SetActive(false);

        if (panelDecisionD5 != null)
        {
            panelDecisionD5.SetActive(true);
        }
    }
}