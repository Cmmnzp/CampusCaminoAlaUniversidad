using UnityEngine;

public class TeoriaMatematica : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelTeoria;

    public GameObject textoInteractuar;

    [Header("Jugador")]
    public player jugador;

    [Header("Puzzle")]
    public GameObject panelPuzzle;

    private bool jugadorCerca = false;

    private bool teoriaVista = false;

    private bool teoriaAbierta = false;

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

        if (teoriaVista)
            return;

        if (textoInteractuar != null && !teoriaAbierta)
        {
            textoInteractuar.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !teoriaAbierta)
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
            {
                textoInteractuar.SetActive(false);
            }
        }
    }

    void AbrirTeoria()
    {
        teoriaAbierta = true;

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
        teoriaAbierta = false;

        if (panelTeoria != null)
            panelTeoria.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = true;

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Resuelve la secuencia matematica"
            );
        }

        if (panelPuzzle != null)
        {
            panelPuzzle.SetActive(true);
        }

        if (textoInteractuar != null)
        {
            textoInteractuar.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}