using UnityEngine;

public class TeoriaInteractiva : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelTeoria;

    public GameObject textoInteractuar;

    [Header("Jugador")]
    public player jugador;

    [Header("Puzzle")]
    public GameObject panelPuzzle;

    [Header("Objeto Libro")]
    public GameObject libroObjeto;

    private bool jugadorCerca = false;

    private bool teoriaVista = false;

    void Start()
    {
        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (panelTeoria != null)
            panelTeoria.SetActive(false);

        if (panelPuzzle != null)
            panelPuzzle.SetActive(false);
    }

    void Update()
    {
        if (!jugadorCerca)
            return;

        if (!teoriaVista && textoInteractuar != null)
        {
            textoInteractuar.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !teoriaVista)
        {
            AbrirTeoria();
        }
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
                textoInteractuar.SetActive(false);
        }
    }

    void AbrirTeoria()
    {
        teoriaVista = true;

        if (panelTeoria != null)
            panelTeoria.SetActive(true);

        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = false;
    }

    public void CerrarTeoria()
    {
        if (panelTeoria != null)
            panelTeoria.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = true;

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Organiza correctamente el algoritmo"
            );
        }

        if (panelPuzzle != null)
        {
            panelPuzzle.SetActive(true);
        }

        if (libroObjeto != null)
        {
            libroObjeto.SetActive(false);
        }
    }
}