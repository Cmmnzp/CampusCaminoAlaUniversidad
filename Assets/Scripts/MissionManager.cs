using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instancia;

    private int estado = 0;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        MissionUI.instancia.ActualizarMision("Ve donde Mateo");
    }

    public void SiguienteMision()
    {
        estado++;

        switch (estado)
        {
            case 1:
                MissionUI.instancia.ActualizarMision("Sigue el tutorial de movimiento");
                break;

            case 2:
                MissionUI.instancia.ActualizarMision("Sigue a Mateo hasta el aula");
                break;

            case 3:
                MissionUI.instancia.ActualizarMision("Habla con el profesor");
                break;

            case 4:
                MissionUI.instancia.ActualizarMision("Bienvenido al Día 2");
                break;

            case 5:
                MissionUI.instancia.ActualizarMision("Habla con el profesor");
                break;

            case 6:
                MissionUI.instancia.ActualizarMision("Completa tu primera actividad");
                break;
        }
    }
}