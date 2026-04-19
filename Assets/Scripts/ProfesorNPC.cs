using UnityEngine;
using TMPro;

public class ProfesorNPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public GameObject textoInteractuar;

    public Transform jugador;
    public float distanciaInteraccion = 6f;

    private bool yaHablo = false;
    private int estadoDialogo = 0;

    void Start()
    {
        textoInteractuar.SetActive(false);
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        // 🔍 DEBUG (míralo en consola)
        Debug.Log("Distancia al profesor: " + distancia + " | yaHablo: " + yaHablo + " | estado: " + estadoDialogo);

        if (distancia < distanciaInteraccion && yaHablo == false)
        {
            textoInteractuar.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                AbrirDialogo();
            }
        }
        else
        {
            textoInteractuar.SetActive(false);
        }
    }

    void AbrirDialogo()
    {
        panelDialogo.SetActive(true);
        Time.timeScale = 0f;

        if (estadoDialogo == 0)
        {
            textoDialogo.text = "Bienvenido al semestre. Tendrás 7 días para aprobar.";
        }
        else if (estadoDialogo == 1)
        {
            textoDialogo.text = "Perfecto. Ahora realiza la actividad del día 2.";
        }

        yaHablo = true;
        textoInteractuar.SetActive(false);
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        Time.timeScale = 1f;

        if (estadoDialogo == 0)
        {
            // TERMINA DÍA 1
            if (MissionManager.instancia != null)
                MissionManager.instancia.SiguienteMision();

            if (DayManager.instancia != null)
                DayManager.instancia.SiguienteDia();

            // 🔥 FORZAMOS CAMBIO A DÍA 2
            Invoke("ActivarDia2", 2f);
        }
        else if (estadoDialogo == 1)
        {
            if (MissionManager.instancia != null)
                MissionManager.instancia.SiguienteMision();
        }
    }

    void ActivarDia2()
    {
        Debug.Log("🔥 ACTIVANDO DÍA 2 EN PROFESOR");

        estadoDialogo = 1;
        yaHablo = false;

        // 🔥 FORZAR que aparezca interacción
        if (textoInteractuar != null)
            textoInteractuar.SetActive(true);
    }
}