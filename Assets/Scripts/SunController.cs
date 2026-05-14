using UnityEngine;

public class SunController : MonoBehaviour
{
    public Light sun;

    [Header("Tiempo del día")]
    public float duracionDia = 60f; 

    private float tiempoActual = 0f;

    void Update()
    {
        if (sun == null) return;

        
        tiempoActual += Time.deltaTime;

        float progreso = tiempoActual / duracionDia;

        float angulo = progreso * 360f - 90f;

        sun.transform.rotation = Quaternion.Euler(angulo, 170f, 0);

        if (progreso >= 1f)
        {
            tiempoActual = 0f;
        }
    }
}