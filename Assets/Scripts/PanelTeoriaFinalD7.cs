using UnityEngine;

public class PanelTeoriaFinalD7 : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelTeoria;

    public GameObject panelExamenFinal;

    [Header("Jugador")]
    public player jugador;

    
    public void ComenzarExamenFinal()
    {
        if (panelTeoria != null)
        {
            panelTeoria.SetActive(false);
        }

        
        if (panelExamenFinal != null)
        {
            panelExamenFinal.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Responde correctamente el examen final"
            );
        }

        
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }
    }
}