using UnityEngine;
using TMPro;

public class NPC_MateoD4 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    [Header("Decision")]
    public GameObject panelDecisionD4;

    [Header("Paneles Narrativos")]
    public GameObject panelSolo;

    public GameObject panelEquipo;

    [Header("Jugador")]
    public player jugador;

    public PlayerStats stats;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private bool interaccionFinalizada = false;

    private int estadoDialogo = 0;

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (panelDecisionD4 != null)
            panelDecisionD4.SetActive(false);

        if (panelSolo != null)
            panelSolo.SetActive(false);

        if (panelEquipo != null)
            panelEquipo.SetActive(false);
    }

    void Update()
    {
        if (interaccionFinalizada)
            return;

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

        if (panelDialogo != null)
            panelDialogo.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (jugador != null)
            jugador.puedeMoverse = false;

        MostrarDialogo();
    }

    public void BotonSiguiente()
    {
        estadoDialogo++;

        if (estadoDialogo > 2)
        {
            AbrirDecision();
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
                    "Ese proyecto estuvo complicado... pero lo logramos.";

                break;

            case 1:

                textoDialogo.text =
                    "Aún quedan muchas entregas este semestre.";

                break;

            case 2:

                textoDialogo.text =
                    "¿Quieres seguir trabajando solo o hacemos equipo otra vez?";

                break;
        }
    }

    void AbrirDecision()
    {
        dialogoActivo = false;

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (panelDecisionD4 != null)
            panelDecisionD4.SetActive(true);
    }


    public void ElegirSolo()
    {
        if (panelDecisionD4 != null)
            panelDecisionD4.SetActive(false);

        if (panelSolo != null)
            panelSolo.SetActive(true);
    }


    public void ElegirEquipo()
    {
        if (panelDecisionD4 != null)
            panelDecisionD4.SetActive(false);

        if (panelEquipo != null)
            panelEquipo.SetActive(true);
    }


    public void ContinuarSolo()
    {
        if (panelSolo != null)
            panelSolo.SetActive(false);

        if (stats != null)
        {
            stats.AumentarConocimiento(12);
        }

        FinalizarDia("Trabajaste solo");
    }


    public void ContinuarEquipo()
    {
        if (panelEquipo != null)
            panelEquipo.SetActive(false);

        if (stats != null)
        {
            stats.AumentarConocimiento(8);

            stats.AumentarRelaciones(5);
        }

        FinalizarDia("Trabajaste con Mateo");
    }


    void FinalizarDia(string decision)
    {
        interaccionFinalizada = true;

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (DayEndManager.instancia != null)
        {
            DayEndManager.instancia.TerminarDia(decision);
        }

        Debug.Log("Dia 4 finalizado");
    }

    void OnTriggerEnter(Collider other)
    {
        if (interaccionFinalizada)
            return;

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