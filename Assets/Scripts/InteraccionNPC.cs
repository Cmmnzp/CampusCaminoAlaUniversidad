using UnityEngine;

public class InteraccionNPC : MonoBehaviour
{
    public GameObject indicadorE;
    public GameObject panelDialogo;

    public bool puedeInteractuar = true;

    private bool jugadorCerca = false;

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }

    void Update()
    {
        // 🔴 Si no puede interactuar
        if (!puedeInteractuar)
        {
            if (indicadorE != null)
                indicadorE.SetActive(false);

            return;
        }

        // 🟢 Si el jugador está cerca
        if (jugadorCerca)
        {
            Debug.Log("Jugador cerca - debería aparecer la E"); // 🔥 DEBUG

            if (indicadorE != null)
            {
                indicadorE.SetActive(true);
            }
            else
            {
                Debug.LogWarning("⚠️ indicadorE NO está asignado");
            }

            // 👉 Presionar tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Se presionó E - Abriendo diálogo"); // 🔥 DEBUG

                if (panelDialogo != null)
                {
                    panelDialogo.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("⚠️ panelDialogo NO está asignado");
                }
            }
        }
        else
        {
            if (indicadorE != null)
                indicadorE.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en trigger con: " + other.name); // 🔥 DEBUG

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado en trigger"); // 🔥 DEBUG
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Salió del trigger: " + other.name); // 🔥 DEBUG

        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            if (panelDialogo != null)
                panelDialogo.SetActive(false);
        }
    }

    // 🔵 Botón SI (para UI)
    public void BotonSi()
    {
        Debug.Log("Botón SI presionado"); // 🔥 DEBUG

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        MateoMovement mateo = GetComponent<MateoMovement>();

        if (mateo != null)
        {
            mateo.EmpezarMovimiento();
        }
        else
        {
            Debug.LogWarning("⚠️ MateoMovement NO encontrado en este objeto");
        }
    }

    // 🔴 Botón NO
    public void BotonNo()
    {
        Debug.Log("Botón NO presionado"); // 🔥 DEBUG

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }
}