using UnityEngine;

public class MinimapRotate : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        if (jugador == null) return;

        float rotacion = jugador.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, 0, rotacion);
    }
}
