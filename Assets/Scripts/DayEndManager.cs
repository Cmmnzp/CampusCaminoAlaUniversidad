using UnityEngine;

public class DayEndManager : MonoBehaviour
{
    public static DayEndManager instancia;

    [Header("Resumen del día")]
    public ResumenDia resumenDia;

    void Awake()
    {
        instancia = this;
    }

    public void TerminarDia(string decision)
    {
        if (resumenDia != null)
        {
            resumenDia.MostrarResumen(decision);
        }
    }
}