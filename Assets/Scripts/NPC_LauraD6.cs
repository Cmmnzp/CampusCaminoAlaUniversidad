using UnityEngine;
using TMPro;

public class NPC_LauraD6 : MonoBehaviour
{
    [Header("UI")]
    public GameObject indicadorE;

    public GameObject panelDialogo;

    public TextMeshProUGUI textoDialogo;

    [Header("Reporte Academico")]
    public GameObject panelReporte;

    [Header("Jugador")]
    public player jugador;

    private bool jugadorCerca = false;

    private bool dialogoActivo = false;

    private bool interaccionFinalizada = false;

    private bool inputBloqueado = false;

    private int estadoDialogo = 0;

    private string[] dialogos =
    {
        "Alex, las evaluaciones finales estan muy cerca.",

        "Tus resultados han mejorado, pero el nivel academico sera mucho mas exigente.",

        "He revisado tu progreso y aun existen riesgos importantes en algunas areas.",

        "Antes de continuar debes revisar cuidadosamente tu reporte academico."
    };

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (panelReporte != null)
            panelReporte.SetActive(false);
    }

    void Update()
    {
        if (!jugadorCerca)
            return;

        if (inputBloqueado)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogoActivo && !interaccionFinalizada)
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

        if (panelReporte != null)
        {
            panelReporte.SetActive(true);
        }

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Revisa tu reporte academico"
            );
        }

        if (indicadorE != null)
        {
            indicadorE.SetActive(false);
        }

        Collider col = GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
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