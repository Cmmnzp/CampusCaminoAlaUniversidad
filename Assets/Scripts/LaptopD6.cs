using UnityEngine;

public class LaptopD6 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelApuntes;

    [Header("Director")]
    public GameObject directorD6;

    [Header("Visual Laptop")]
    public GameObject laptopVisual;

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

        if (panelApuntes != null)
        {
            panelApuntes.SetActive(false);
        }

        if (directorD6 != null)
        {
            directorD6.SetActive(false);
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

        if (panelApuntes != null)
        {
            panelApuntes.SetActive(true);
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
            MissionManager.instancia.SetEstado(3);

            MissionManager.instancia.AsignarMision(
                "Lee cuidadosamente los apuntes finales"
            );
        }
    }

    public void Continuar()
    {
        if (panelApuntes != null)
        {
            panelApuntes.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarConocimiento(8);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        if (laptopVisual != null)
        {
            laptopVisual.SetActive(false);
        }

        if (directorD6 != null)
        {
            directorD6.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(4);

            MissionManager.instancia.AsignarMision(
                "Habla con el Profesor"
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