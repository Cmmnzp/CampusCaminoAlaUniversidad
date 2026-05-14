using UnityEngine;
using TMPro;

public class NPC_Laura : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    [Header("Libro Matematico")]
    public GameObject libroMatematico;

    [Header("Decision")]
    public LauraDecisionManager decisionManager;

    [Header("Jugador")]
    public player jugador;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private bool interaccionFinalizada = false;

    private bool esperandoDecision = false;

    private bool inputBloqueado = false;

    private int estadoDialogo = 0;

    private string[] dialogos =
    {
        "Hola Alex, hoy trabajaremos secuencias matematicas.",

        "Las secuencias siguen patrones logicos que debes aprender a identificar.",

        "Antes de resolver la actividad, debes estudiar los ejemplos matematicos.",

        "Acercate al libro matematico y analiza cuidadosamente los patrones."
    };

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (libroMatematico != null)
            libroMatematico.SetActive(false);
    }

    void Update()
    {
        if (!jugadorCerca)
            return;

        if (inputBloqueado)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (esperandoDecision)
            {
                AbrirDecision();
            }
            else if (!dialogoActivo && !interaccionFinalizada)
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

        MostrarDialogo();

        Invoke(nameof(DesbloquearInput), 0.5f);
    }

    void MostrarDialogo()
    {
        if (textoDialogo != null)
        {
            textoDialogo.text = dialogos[estadoDialogo];
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

        Invoke(nameof(DesbloquearInput), 0.3f);
    }

    void FinalizarDialogo()
    {
        dialogoActivo = false;

        interaccionFinalizada = true;

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }

        if (libroMatematico != null)
        {
            libroMatematico.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Estudia las secuencias matematicas"
            );
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }
    }

    public void ActivarDecisionFinal()
    {
        esperandoDecision = true;

        dialogoActivo = false;

        interaccionFinalizada = false;

        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(true);
        }
    }

    void AbrirDecision()
    {
        dialogoActivo = true;

        if (decisionManager != null)
        {
            decisionManager.AbrirDecision();
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }
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

            if (indicadorE != null)
            {
                indicadorE.SetActive(true);
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