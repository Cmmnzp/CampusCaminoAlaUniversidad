using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform jugador;
    public float altura = 20f;

    void LateUpdate()
    {
        if (jugador == null) return;

        transform.position = new Vector3(
            jugador.position.x,
            jugador.position.y + altura,
            jugador.position.z
        );
    }
}