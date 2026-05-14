using UnityEngine;

public class LibroFelipe : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelTeoria;

    public GameObject textoInteractuar;

    [Header("Jugador")]
    public player jugador;

    [Header("Proyecto")]
    public GameObject panelProyecto;

    [Header("NPC Felipe")]
    public NPC_Felipe npcFelipe;

    private bool jugadorCerca = false;

    private bool teoriaVista = false;

    void Start()
    {
        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (panelTeoria != null)
            panelTeoria.SetActive(false);
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
            {
                textoInteractuar.SetActive(false);
            }
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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarTeoria()
    {
        if (panelTeoria != null)
            panelTeoria.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = true;

        // 🔥 NUEVA MISIÓN
        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(2);

            MissionManager.instancia.AsignarMision(
                "Organiza correctamente el algoritmo"
            );
        }

        // 🔥 ABRIR PROYECTO
        if (npcFelipe != null)
        {
            npcFelipe.AbrirProyecto();
        }

        gameObject.SetActive(false);
    }
}