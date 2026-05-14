using UnityEngine;

public class DirectorD6 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDirector;

    [Header("Paneles Finales")]
    public GameObject panelFinalEstudiar;

    public GameObject panelFinalDormir;

    [Header("Jugador")]
    public player jugador;

    [Header("Stats")]
    public PlayerStats stats;

    private bool jugadorCerca = false;

    private bool yaInteractuo = false;

    void Start()
    {
        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        if (panelDirector != null)
        {
            panelDirector.SetActive(false);
        }

        if (panelFinalEstudiar != null)
        {
            panelFinalEstudiar.SetActive(false);
        }

        if (panelFinalDormir != null)
        {
            panelFinalDormir.SetActive(false);
        }
    }

    void Update()
    {
        if (jugadorCerca &&
            !yaInteractuo &&
            Input.GetKeyDown(KeyCode.E))
        {
            AbrirPanel();
        }
    }

    
    void AbrirPanel()
    {
        yaInteractuo = true;

        if (panelDirector != null)
        {
            panelDirector.SetActive(true);
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(5);

            MissionManager.instancia.AsignarMision(
                "Toma tu decision final para prepararte"
            );
        }
    }

    public void ElegirEstudiar()
    {
        if (panelDirector != null)
        {
            panelDirector.SetActive(false);
        }

        if (panelFinalEstudiar != null)
        {
            panelFinalEstudiar.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ElegirDescansar()
    {
        if (panelDirector != null)
        {
            panelDirector.SetActive(false);
        }

        if (panelFinalDormir != null)
        {
            panelFinalDormir.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinuarEstudiar()
    {
        if (panelFinalEstudiar != null)
        {
            panelFinalEstudiar.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarConocimiento(10);

            stats.AumentarEstres(15);

            stats.ReducirEnergia(10);
        }

        FinalizarDia(
            "Alex decidio seguir estudiando hasta tarde"
        );
    }

    public void ContinuarDormir()
    {
        if (panelFinalDormir != null)
        {
            panelFinalDormir.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarEnergia(15);

            stats.ReducirEstres(10);
        }

        FinalizarDia(
            "Alex decidio descansar antes del examen final"
        );
    }

    void FinalizarDia(string decision)
    {
        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Decision Final D6: " + decision);

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(6);

            MissionManager.instancia.AsignarMision(
                "Dia 6 completado"
            );
        }

        if (DayEndManager.instancia != null)
        {
            DayEndManager.instancia.TerminarDia(decision);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            if (!yaInteractuo)
            {
                if (indicadorE != null)
                {
                    indicadorE.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            if (indicadorE != null)
            {
                indicadorE.SetActive(false);
            }
        }
    }
}