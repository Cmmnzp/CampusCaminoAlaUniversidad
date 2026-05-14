using UnityEngine;

public class LibroCarlosD5 : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelTeoria;

    public GameObject textoInteractuar;

    [Header("Jugador")]
    public player jugador;

    [Header("Parcial")]
    public GameObject panelParcial;

    private bool jugadorCerca = false;

    private bool teoriaVista = false;

    void Start()
    {
        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (panelTeoria != null)
            panelTeoria.SetActive(false);

        if (panelParcial != null)
            panelParcial.SetActive(false);
    }

    void Update()
    {
        if (!jugadorCerca)
            return;

        if (!teoriaVista)
        {
            if (textoInteractuar != null)
            {
                textoInteractuar.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                AbrirTeoria();
            }
        }
    }

    void AbrirTeoria()
    {
        teoriaVista = true;

        if (panelTeoria != null)
        {
            panelTeoria.SetActive(true);
        }

        if (textoInteractuar != null)
        {
            textoInteractuar.SetActive(false);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BotonEntendido()
    {
        if (panelTeoria != null)
        {
            panelTeoria.SetActive(false);
        }

        if (panelParcial != null)
        {
            panelParcial.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Responde el parcial"
            );
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            if (textoInteractuar != null)
            {
                textoInteractuar.SetActive(false);
            }
        }
    }
}