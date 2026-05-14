using UnityEngine;

public class DialogueMateo : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;

    [Header("Jugador")]
    public PlayerStats player;

    [Header("Mateo")]
    public MateoMovement mateo;

    // 🟢 OPCIÓN SÍ
    public void OpcionSi()
    {
        // 🔥 Aumentar relaciones correctamente
        if (player != null)
        {
            player.AumentarRelaciones(25);
        }

        // 🔥 Avanzar misión
        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SiguienteMision();
        }

        // 🔥 Iniciar movimiento de Mateo
        if (mateo != null)
        {
            mateo.EmpezarMovimiento();
        }

        Cerrar();
    }

    // 🔴 OPCIÓN NO
    public void OpcionNo()
    {
        // 🔥 Reducir relaciones correctamente
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