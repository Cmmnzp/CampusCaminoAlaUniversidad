using UnityEngine;

public class DialogueMateo : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;

    [Header("Jugador")]
    public PlayerStats player;

    [Header("Mateo")]
    public MateoMovement mateo;

    public void OpcionSi()
    {
        if (player != null)
        {
            player.AumentarRelaciones(25);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SiguienteMision();
        }

        if (mateo != null)
        {
            mateo.EmpezarMovimiento();
        }

        Cerrar();
    }

    public void OpcionNo()
    {
        if (player != null)
        {
            player.ReducirRelaciones(25);
        }

        Cerrar();
    }

    void Cerrar()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }

        Time.timeScale = 1f;
    }
}