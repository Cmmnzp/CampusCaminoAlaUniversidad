using UnityEngine;
using TMPro;

public class ResumenDia : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textoResumen;

    public PlayerStats stats;

    public player jugador;

    public void MostrarResumen(string decision)
    {
        panel.SetActive(true);

        if (jugador != null)
            jugador.puedeMoverse = false;

        string resumen = "DÍA COMPLETADO\n\n";

        resumen += "Decisión: " + decision + "\n\n";

        resumen += "ESTADO ACTUAL:\n";
        resumen += "Conocimiento: " + stats.conocimiento + "\n";
        resumen += "Estrés: " + stats.estres + "\n";
        resumen += "Relaciones: " + stats.relaciones + "\n";

        textoResumen.text = resumen;
    }

    public void Continuar()
    {
        panel.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = true;

        if (DayManager.instancia != null)
            DayManager.instancia.SiguienteDia();
    }
}