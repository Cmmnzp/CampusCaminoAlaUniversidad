using UnityEngine;

public class DialogueMateo : MonoBehaviour
{
    public GameObject panel;
    public PlayerStats player;

    public MateoMovement mateo;

    public void OpcionSi()
    {
        player.relaciones += 25;

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
        player.relaciones -= 25;
        Cerrar();
    }

    void Cerrar()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}