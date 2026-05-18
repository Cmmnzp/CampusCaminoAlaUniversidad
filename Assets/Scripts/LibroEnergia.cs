using UnityEngine;

public class LibroEnergia : MonoBehaviour
{
    [Header("Energía")]
    public float energiaQueDa = 5f;

    [Header("Destruir")]
    public bool destruirAlRecoger = true;

    [Header("Animación")]
    public float velocidadRotacion = 60f;
    public float velocidadFlotar = 2f;
    public float alturaFlotar = 0.25f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {

        transform.Rotate(0,
            velocidadRotacion * Time.deltaTime,
            0);


        float nuevaAltura =
            Mathf.Sin(Time.time * velocidadFlotar)
            * alturaFlotar;

        transform.position =
            posicionInicial + Vector3.up * nuevaAltura;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerStats stats =
                other.GetComponent<PlayerStats>();

            if (stats != null)
            {
                stats.AumentarEnergia(energiaQueDa);

                Debug.Log("Libro recogido");

                if (destruirAlRecoger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}