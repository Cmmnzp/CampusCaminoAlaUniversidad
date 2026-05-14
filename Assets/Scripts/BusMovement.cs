using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public Transform[] puntos;

    public float velocidad = 8f;

    public float distanciaMinima = 1f;

    private int puntoActual = 0;

    void Update()
    {
        if (puntos.Length == 0)
            return;

        Transform objetivo =
            puntos[puntoActual];

        Vector3 direccion =
            (objetivo.position - transform.position).normalized;

        transform.position +=
            direccion *
            velocidad *
            Time.deltaTime;

        transform.LookAt(
            new Vector3(
                objetivo.position.x,
                transform.position.y,
                objetivo.position.z
            )
        );

        float distancia =
            Vector3.Distance(
                transform.position,
                objetivo.position
            );

        if (distancia < distanciaMinima)
        {
            puntoActual++;

            if (puntoActual >= puntos.Length)
            {
                puntoActual = 0;
            }
        }
    }
}