using UnityEngine;
using TMPro;

public class TextoApuntesD6 : MonoBehaviour
{
    public PlayerStats stats;

    public TextMeshProUGUI textoReflexion;

    void OnEnable()
    {
        GenerarReflexion();
    }

    void GenerarReflexion()
    {
        if (stats == null || textoReflexion == null)
            return;

        string reflexion = "";

        if (stats.conocimiento >= 70)
        {
            reflexion +=
                "Alex observa sus apuntes y siente que ha aprendido mucho durante el semestre.\n\n";
        }
        else if (stats.conocimiento >= 40)
        {
            reflexion +=
                "Aun quedan conceptos por mejorar, pero Alex reconoce el progreso logrado.\n\n";
        }
        else
        {
            reflexion +=
                "Los apuntes parecen mas dificiles de lo normal y Alex siente inseguridad frente al examen final.\n\n";
        }

        if (stats.estres >= 70)
        {
            reflexion +=
                "El cansancio acumulado comienza a afectar su concentracion.\n\n";
        }
        else if (stats.estres >= 40)
        {
            reflexion +=
                "La presion academica sigue presente, pero aun puede mantenerse enfocado.\n\n";
        }
        else
        {
            reflexion +=
                "Alex respira tranquilo y mantiene la calma antes de la evaluacion final.\n\n";
        }

        if (stats.energia >= 70)
        {
            reflexion +=
                "Todavia conserva energia suficiente para seguir preparandose.\n\n";
        }
        else if (stats.energia >= 40)
        {
            reflexion +=
                "El agotamiento empieza a sentirse despues de tantos dias de estudio.\n\n";
        }
        else
        {
            reflexion +=
                "Cada pagina cuesta mas leerla debido al agotamiento fisico y mental.\n\n";
        }

        reflexion +=
            "El examen final esta cada vez mas cerca.\n"
            + "Todo el esfuerzo realizado comenzara a reflejarse.";

        textoReflexion.text = reflexion;
    }
}