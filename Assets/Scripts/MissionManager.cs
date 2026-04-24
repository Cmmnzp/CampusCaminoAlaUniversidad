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
        ActualizarMisionPorDia();
    }

    public void SiguienteMision()
    {
        estado++;

        Debug.Log("Estado de misión: " + estado);

        int dia = DayManager.instancia != null ? DayManager.instancia.diaActual : 1;

        switch (dia)
        {
            case 1:
                MisionesDia1();
                break;

            case 2:
                MisionesDia2();
                break;

            case 3:
                MisionesDia3();
                break;
        }
    }

    // 🔴 DÍA 1
    void MisionesDia1()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Ve donde Mateo");
                break;

            case 1:
                AsignarMision("Sigue el tutorial de movimiento");
                break;

            case 2:
                AsignarMision("Sigue a Mateo hasta el aula");
                break;

            case 3:
                AsignarMision("Habla con el profesor");
                break;
        }
    }

    // 🔵 DÍA 2 (ACTUALIZADO)
    void MisionesDia2()
    {
        switch (estado)
        {
            case 4:
                AsignarMision("Bienvenido al Día 2");
                break;

            case 5:
                AsignarMision("Habla con El Profesor");
                break;

            case 6:
                AsignarMision("Ordena el algoritmo correctamente");
                break;

            // 🔥 NUEVO
            case 7:
                AsignarMision("Decide cómo estudiar con Mateo");
                break;

            // 🔥 NUEVO
            case 8:
                AsignarMision("Proyecto asignado");
                break;
        }
    }

    // 🟢 DÍA 3
    void MisionesDia3()
    {
        switch (estado)
        {
            case 0:
                AsignarMision("Bienvenido al Día 3");
                break;

            case 1:
                AsignarMision("Explora el entorno");
                break;
        }
    }

    public void AsignarMision(string texto)
    {
        Debug.Log("Nueva misión: " + texto);

        if (MissionUI.instancia != null)
        {
            MissionUI.instancia.ActualizarMision(texto);
        }
    }

    public void ActualizarMisionPorDia()
    {
        int dia = DayManager.instancia != null ? DayManager.instancia.diaActual : 1;

        estado = 0;

        switch (dia)
        {
            case 1:
                MisionesDia1();
                break;

            case 2:
                estado = 4;
                MisionesDia2();
                break;

            case 3:
                estado = 0;
                MisionesDia3();
                break;
        }
    }

    public void SetEstado(int nuevoEstado)
    {
        estado = nuevoEstado;
        Debug.Log("Estado forzado a: " + estado);
    }
}