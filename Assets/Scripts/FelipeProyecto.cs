using UnityEngine;

public class FelipeProyecto : MonoBehaviour
{
    [Header("Panel Proyecto")]
    public GameObject panelProyecto;

    [Header("Jugador")]
    public MonoBehaviour playerMovement;

    public void AbrirProyecto()
    {
        // Mostrar panel
        panelProyecto.SetActive(true);

        // Desbloquear cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bloquear movimiento
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        Debug.Log("Proyecto Día 4 iniciado");
    }

    public void CerrarProyecto()
    {
        // Ocultar panel
        panelProyecto.SetActive(false);

        // Bloquear cursor nuevamente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Activar movimiento
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        Debug.Log("Proyecto cerrado");
    }
}