using UnityEngine;

public class FelipeProyecto : MonoBehaviour
{
    [Header("Panel Proyecto")]
    public GameObject panelProyecto;

    [Header("Jugador")]
    public MonoBehaviour playerMovement;

    public void AbrirProyecto()
    {
        panelProyecto.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        Debug.Log("Proyecto Día 4 iniciado");
    }

    public void CerrarProyecto()
    {
        panelProyecto.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        Debug.Log("Proyecto cerrado");
    }
}