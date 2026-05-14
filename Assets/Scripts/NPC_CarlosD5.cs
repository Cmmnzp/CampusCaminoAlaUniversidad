using UnityEngine;
using TMPro;

public class NPC_CarlosD5 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    [Header("Libro")]
    public GameObject libroD5;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private bool yaInteractuo = false;

    private int estadoDialogo = 0;

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (libroD5 != null)
            libroD5.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca &&
            !yaInteractuo &&
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
        {
            panelDialogo.SetActive(true);
        }

        MostrarDialogo();
    }

    public void BotonSiguiente()
    {
        estadoDialogo++;

        if (estadoDialogo > 3)
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
                    "Buenos dias Alex. Hoy presentaras tu primer parcial.";

                break;

            case 1:

                textoDialogo.text =
                    "Las preguntas evaluaran conceptos basicos de programacion.";

                break;

            case 2:

                textoDialogo.text =
                    "Antes del examen debes estudiar cuidadosamente la teoria.";

                break;

            case 3:

                textoDialogo.text =
                    "Cuando estes listo podras comenzar el parcial.";

                break;
        }
    }

    void FinalizarDialogo()
    {
        dialogoActivo = false;

        yaInteractuo = true;

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        if (libroD5 != null)
        {
            libroD5.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Estudia la teoria del parcial"
            );
        }

        Collider col = GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameObject.SetActive(false);
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

            if (panelDialogo != null)
            {
                panelDialogo.SetActive(false);
            }
        }
    }
}