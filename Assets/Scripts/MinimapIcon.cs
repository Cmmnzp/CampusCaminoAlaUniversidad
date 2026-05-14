using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    public Transform objetivo;
    public Transform jugador;
    public RectTransform iconoUI;

    public float escala = 5f;

    void Update()
    {
        if (objetivo == null || jugador == null) return;

        Vector3 direccion = objetivo.position - jugador.position;

        float angulo = jugador.eulerAngles.y * Mathf.Deg2Rad;

        float cos = Mathf.Cos(angulo);
        float sin = Mathf.Sin(angulo);

        float x = direccion.x * cos + direccion.z * sin;
        float y = -direccion.x * sin + direccion.z * cos;

        iconoUI.anchoredPosition = new Vector2(x, y) * escala;
    }
}