using UnityEngine;
using TMPro;

public class DirectorD7 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    [Header("Teoria Final")]
    public GameObject panelTeoriaFinal;

    [Header("Jugador")]
    public player jugador;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private bool interaccionFinalizada = false;

    private bool inputBloqueado = false;

    private int estadoDialogo = 0;

    private string[] dialogos =
    {
        "Alex, hoy presentaras el examen final del semestre.",

        "Esta evaluacion reunira todos los temas trabajados durante los ultimos dias.",

        "Variables, algoritmos, estructuras condicionales, ciclos y logica de programacion seran fundamentales.",

        "El conocimiento acumulado durante el semestre influira directamente en tu resultado final.",

        "Antes de comenzar, revisa cuidadosamente la teoria final."
    };

    void Start()
    {
        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }

        if (panelTeoriaFinal != null)
        {
            panelTeoriaFinal.SetActive(false);
        }
    }

    void Update()
    {
        if (!jugadorCerca)
            return;

        if (inputBloqueado)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogoActivo &&
                !interaccionFinalizada)
            {
                IniciarDialogo();
            }
        }
    }

    
    void IniciarDialogo()
    {
        dialogoActivo = true;

        estadoDialogo = 0;

        inputBloqueado = true;

        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(true);
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        MostrarDialogo();

        Invoke(nameof(DesbloquearInput), 0.4f);
    }

    

    void MostrarDialogo()
    {
        if (textoDialogo != null)
        {
            textoDialogo.text =
                dialogos[estadoDialogo];
        }
    }

    public void BotonSiguiente()
    {
        if (inputBloqueado)
            return;

        inputBloqueado = true;

        estadoDialogo++;

        if (estadoDialogo >= dialogos.Length)
        {
            FinalizarDialogo();
            return;
        }

        MostrarDialogo();

        Invoke(nameof(DesbloquearInput), 0.25f);
    }

    void FinalizarDialogo()
    {
        dialogoActivo = false;

        interaccionFinalizada = true;

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }

        if (panelTeoriaFinal != null)
        {
            panelTeoriaFinal.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Revisa la teoria del examen final"
            );
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void DesbloquearInput()
    {
        inputBloqueado = false;
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            if (!interaccionFinalizada)
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