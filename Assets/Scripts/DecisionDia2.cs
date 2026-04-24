using UnityEngine;
using TMPro;

public class DecisionDia2 : MonoBehaviour
{
    public GameObject panel;
    public PlayerStats stats;

    public player jugador;

    public UI_DecisionAnimada uiAnimado;

    public TextMeshProUGUI textoResultado;

    public void MostrarDecision()
    {
        if (jugador != null)
            jugador.puedeMoverse = false;

        if (uiAnimado != null)
        {
            uiAnimado.Mostrar();
        }
        else
        {
            panel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void ElegirJuntos()
    {
        if (stats != null)
        {
            stats.relaciones += 25;
            stats.AumentarConocimiento(20);
        }

        if (textoResultado != null)
            textoResultado.text = "Estudiaron juntos (+Relaciones, +Conocimiento)";

        FinalizarDecision();
    }
    public void ElegirSolo()
    {
        if (stats != null)
        {
            stats.AumentarConocimiento(30);
        }

        if (textoResultado != null)
            textoResultado.text = "Estudiaste solo (+Conocimiento)";

        FinalizarDecision();
    }

    void FinalizarDecision()
    {
        if (uiAnimado != null)
        {
            uiAnimado.Ocultar();
        }
        else if (panel != null)
        {
            panel.SetActive(false);
        }

        if (jugador != null)
            jugador.puedeMoverse = true;

        Time.timeScale = 2f;

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.AsignarMision("Proyecto asignado");
        }

        if (DayManager.instancia != null)
        {
            DayManager.instancia.SiguienteDia();
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.ActualizarMisionPorDia();
        }

        Debug.Log("✅ Decisión completada → Día 3");
    }
}