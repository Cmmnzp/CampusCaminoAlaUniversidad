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
        // =====================================================
        // ROTAR LIBRO
        // =====================================================

        transform.Rotate(0,
            velocidadRotacion * Time.deltaTime,
            0);

        // =====================================================
        // FLOTAR SUAVEMENTE
        // =====================================================

        float nuevaAltura =
            Mathf.Sin(Time.time * velocidadFlotar)
            * alturaFlotar;

        transform.position =
            posicionInicial + Vector3.up * nuevaAltura;
    }

    private void OnTriggerEnter(Collider other)
    {
        // =====================================================
        // DETECTAR JUGADOR
        // =====================================================

        if (other.CompareTag("Player"))
        {
            PlayerStats stats =
                other.GetComponent<PlayerStats>();

            if (stats != null)
            {
                // DAR ENERGÍA
                stats.AumentarEnergia(energiaQueDa);

                Debug.Log("Libro recogido");

                // DESTRUIR LIBRO
                if (destruirAlRecoger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}