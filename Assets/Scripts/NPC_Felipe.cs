using UnityEngine;
using TMPro;

public class NPC_Felipe : MonoBehaviour
{
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    public GameObject libroTeoria;

    public GameObject panelProyecto;

    public MonoBehaviour playerMovement;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private int estadoDialogo = 0;

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (libroTeoria != null)
            libroTeoria.SetActive(false);

        if (panelProyecto != null)
            panelProyecto.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca &&
            Input.GetKeyDown(KeyCode.E) &&
            !dialogoActivo)
        {
            IniciarDialogo();
        }
    }

    void IniciarDialogo()
    {
        dialogoActivo = true;

        estadoDialogo = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (panelDialogo != null)
            panelDialogo.SetActive(true);

        MostrarDialogo();
    }

    public void BotonSiguiente()
    {
        estadoDialogo++;

        if (estadoDialogo > 2)
        {
            FinalizarDialogo();
        }
        else
        {
            MostrarDialogo();
        }
    }

    void MostrarDialogo()
    {
        if (textoDialogo == null)
            return;

        switch (estadoDialogo)
        {
            case 0:

                textoDialogo.text =
                    "Buenos dias Alex. Hoy trabajaremos algoritmos y logica.";

                break;

            case 1:

                textoDialogo.text =
                    "Debes estudiar la teoria antes de comenzar.";

                break;

            case 2:

                textoDialogo.text =
                    "Cuando termines el proyecto busca a Mateo.";

                break;
        }
    }

    void FinalizarDialogo()
    {
        dialogoActivo = false;

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (libroTeoria != null)
            libroTeoria.SetActive(true);

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Estudia la teoria de algoritmos"
            );
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (indicadorE != null)
            indicadorE.SetActive(false);

        gameObject.SetActive(false);
    }

    public void AbrirProyecto()
    {
        if (panelProyecto != null)
        {
            panelProyecto.SetActive(true);
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Proyecto Dia 4 iniciado");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            if (indicadorE != null)
                indicadorE.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            if (indicadorE != null)
                indicadorE.SetActive(false);
        }
    }
}