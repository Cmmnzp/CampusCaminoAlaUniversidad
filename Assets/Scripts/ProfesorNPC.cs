using UnityEngine;
using TMPro;

public class ProfesorNPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public GameObject textoInteractuar;

    public Transform jugador;
    public float distanciaInteraccion = 6f;

    public GameObject panelPuzzle; // 🔥 PANEL DEL PUZZLE

    private int estadoDialogo = 0;
    private bool puzzleIniciado = false;

    void Start()
    {
        if (textoInteractuar != null)
            textoInteractuar.SetActive(false);
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaInteraccion)
        {
            if (textoInteractuar != null)
                textoInteractuar.SetActive(true);

            // 🔥 BLOQUEAR INTERACCIÓN SI PUZZLE ABIERTO
            if (panelPuzzle != null && panelPuzzle.activeSelf)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interactuar();
            }
        }
        else
        {
            if (textoInteractuar != null)
                textoInteractuar.SetActive(false);
        }
    }

    void Interactuar()
    {
        // 🔴 DÍA 1
        if (estadoDialogo == 0)
        {
            panelDialogo.SetActive(true);
            Time.timeScale = 0f;
            textoDialogo.text = "Bienvenido al semestre. Tendrás 7 días para aprobar.";
        }
        // 🔵 INICIO DÍA 2
        else if (estadoDialogo == 1)
        {
            panelDialogo.SetActive(true);
            Time.timeScale = 0f;
            textoDialogo.text = "Perfecto. Ahora realiza la actividad del día 2.";
        }
        // 🟢 ACTIVIDAD (PUZZLE)
        else if (estadoDialogo == 2)
        {
            if (!puzzleIniciado)
            {
                Debug.Log("🧩 Abriendo puzzle por primera vez");

                if (panelPuzzle != null)
                    panelPuzzle.SetActive(true);

                if (MissionManager.instancia != null)
                {
                    MissionManager.instancia.AsignarMision("Ordena el algoritmo correctamente");
                }

                puzzleIniciado = true;
            }
        }
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        Time.timeScale = 1f;

        // 🔴 TERMINA DÍA 1
        if (estadoDialogo == 0)
        {
            if (MissionManager.instancia != null)
                MissionManager.instancia.SiguienteMision();

            if (DayManager.instancia != null)
                DayManager.instancia.SiguienteDia();

            estadoDialogo = 1;
        }
        // 🔵 PASA A ACTIVIDAD
        else if (estadoDialogo == 1)
        {
            if (MissionManager.instancia != null)
                MissionManager.instancia.SiguienteMision();

            estadoDialogo = 2;
        }
    }
}