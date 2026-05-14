using UnityEngine;

public class ContinuarReporteD6 : MonoBehaviour
{
    public GameObject panelReporte;

    public player jugador;

    public GameObject bibliotecaD6;

    public void Continuar()
    {
        if (panelReporte != null)
        {
            panelReporte.SetActive(false);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        if (bibliotecaD6 != null)
        {
            bibliotecaD6.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Dirigete a la biblioteca"
            );
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}