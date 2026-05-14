using UnityEngine;
using TMPro;

public class SistemaReporteD6 : MonoBehaviour
{
    [Header("Stats")]
    public PlayerStats stats;

    [Header("UI")]
    public TextMeshProUGUI textoRendimiento;

    public TextMeshProUGUI textoObservaciones;

    public TextMeshProUGUI textoEstadoEmocional;

    public TextMeshProUGUI textoDisciplina;

    public TextMeshProUGUI textoSocial;

    public TextMeshProUGUI textoAlerta;

    public TextMeshProUGUI textoGraduacion;

    void OnEnable()
    {
        GenerarReporte();
    }

    void GenerarReporte()
    {
        if (stats == null)
            return;

        GenerarRendimiento();

        GenerarObservaciones();

        GenerarEstadoEmocional();

        GenerarDisciplina();

        GenerarSocial();

        GenerarAlerta();

        GenerarGraduacion();
    }

    void GenerarRendimiento()
    {
        if (stats.conocimiento >= 70)
        {
            textoRendimiento.text =
                "Rendimiento Academico: SOBRESALIENTE";
        }
        else if (stats.conocimiento >= 40)
        {
            textoRendimiento.text =
                "Rendimiento Academico: ESTABLE";
        }
        else
        {
            textoRendimiento.text =
                "Rendimiento Academico: EN RIESGO";
        }
    }

    void GenerarObservaciones()
    {
        if (stats.conocimiento >= 70)
        {
            textoObservaciones.text =
                "Alex demuestra gran capacidad logica y buena resolucion de problemas.";
        }
        else if (stats.conocimiento >= 40)
        {
            textoObservaciones.text =
                "El estudiante ha mostrado progreso, pero necesita reforzar conceptos.";
        }
        else
        {
            textoObservaciones.text =
                "Se recomienda apoyo academico urgente para evitar bajo rendimiento.";
        }
    }

    void GenerarEstadoEmocional()
    {
        if (stats.estres >= 70)
        {
            textoEstadoEmocional.text =
                "Estado Emocional: Agotamiento academico elevado.";
        }
        else if (stats.estres >= 40)
        {
            textoEstadoEmocional.text =
                "Estado Emocional: Presion moderada.";
        }
        else
        {
            textoEstadoEmocional.text =
                "Estado Emocional: Buen control emocional.";
        }
    }

    void GenerarDisciplina()
    {
        if (stats.energia >= 70)
        {
            textoDisciplina.text =
                "Disciplina: Excelente constancia y energia.";
        }
        else if (stats.energia >= 40)
        {
            textoDisciplina.text =
                "Disciplina: Rendimiento aceptable.";
        }
        else
        {
            textoDisciplina.text =
                "Disciplina: La fatiga podria afectar el examen final.";
        }
    }

    void GenerarSocial()
    {
        if (stats.relaciones >= 70)
        {
            textoSocial.text =
                "Integracion Social: Excelente trabajo colaborativo.";
        }
        else if (stats.relaciones >= 40)
        {
            textoSocial.text =
                "Integracion Social: Adaptacion academica adecuada.";
        }
        else
        {
            textoSocial.text =
                "Integracion Social: Se recomienda mejorar la comunicacion grupal.";
        }
    }

    void GenerarAlerta()
    {
        if (stats.conocimiento < 40 || stats.estres >= 80)
        {
            textoAlerta.text =
                "ALERTA: Existe riesgo academico para la evaluacion final.";
        }
        else
        {
            textoAlerta.text =
                "ALERTA: El estudiante presenta condiciones aceptables.";
        }
    }

    void GenerarGraduacion()
    {
        int probabilidad =
         Mathf.RoundToInt(
        (
            stats.conocimiento +
            stats.energia +
            stats.relaciones
        )
        - stats.estres
        );

        probabilidad = Mathf.Clamp(probabilidad, 0, 100);

        textoGraduacion.text =
            "Probabilidad de Graduacion: " +
            probabilidad +
            "%";
    }
}