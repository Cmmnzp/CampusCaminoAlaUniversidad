using UnityEngine;

public class LibroMagico : MonoBehaviour
{
    [Header("Rotación")]
    public float velocidadRotacion = 50f;

    [Header("Flotación")]
    public float velocidadFlotacion = 2f;
    public float alturaFlotacion = 0.25f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);

        float nuevaY = posicionInicial.y +
            Mathf.Sin(Time.time * velocidadFlotacion) * alturaFlotacion;

        transform.position = new Vector3(
            transform.position.x,
            nuevaY,
            transform.position.z
        );
    }
}