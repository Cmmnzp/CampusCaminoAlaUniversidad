using UnityEngine;
using TMPro;

public class ProfesorNPC : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public GameObject textoInteractuar;

    [Header("Jugador")]
    public player jugador;

    [Header("Libro de teoría")]
    public GameObject libroTeoria;

    private bool jugadorCerca = false;
    private bool dialogoActivo = false;
    private bool interaccionFinalizada = false;

    private int indiceDialogo = 0;

    private string[] dialogos =
    {
        "Así que tú eres Alex...",

        "Mateo me habló de ti. Esta Universidad necesita ayuda.",

        "Durante los próximos días enfrentarás distintas pruebas y desafíos.",

        "Pero antes de resolver cualquier actividad, debes comprender la teoría.",

        "Ese libro contiene los fundamentos de lógica y algoritmos.",

        "Acércate al libro, estudia la información y luego podrás resolver el desafío."
    };

    void Start()
    {
        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (libroTeoria != null)
            libroTeoria.SetActive(false);
    }

    void Update()
    {
        if (interaccionFinalizada)
            return;

        if (!jugadorCerca)
            return;

        if (!dialogoActivo && textoInteractuar != null)
        {
            textoInteractuar.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !dialogoActivo)
        {
            IniciarDialogo();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (interaccionFinalizada)
            return;

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
                textoInteractuar.SetActive(false);
        }
    }

    void IniciarDialogo()
    {
        dialogoActivo = true;
        indiceDialogo = 0;

        if (panelDialogo != null)
            panelDialogo.SetActive(true);

        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = false;

        MostrarDialogo();
    }

    void MostrarDialogo()
    {
        if (textoDialogo != null)
        {
            textoDialogo.text = dialogos[indiceDialogo];
        }
    }

    public void SiguienteDialogo()
    {
        indiceDialogo++;

        if (indiceDialogo >= dialogos.Length)
        {
            FinalizarDialogo();
            return;
        }

        MostrarDialogo();
    }

    void FinalizarDialogo()
    {
        dialogoActivo = false;
        interaccionFinalizada = true;

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);

        if (jugador != null)
            jugador.puedeMoverse = true;

        if (libroTeoria != null)
            libroTeoria.SetActive(true);

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SetEstado(1);

            MissionManager.instancia.AsignarMision(
                "Estudia la teoría del libro"
            );
        }

        if (DayEndManager.instancia != null)
        {
            DayEndManager.instancia.TerminarDia(
                "Conociste al profesor y recibiste tu primera lección"
            );
        }

        enabled = false;

        gameObject.SetActive(false);
    }
}