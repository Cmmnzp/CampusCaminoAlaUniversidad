using UnityEngine;

public class NPC_Luis : MonoBehaviour
{
    public GameObject indicadorE;
    public GameObject panelDialogo; // opcional (puedes no usarlo)
    public DecisionDia2 decision;

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
        if (!jugadorCerca) return;

        if (indicadorE != null)
            indicadorE.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Luis: interacción activada");

            // 🔥 IMPORTANTE: abrir decisión directamente
            if (decision != null)
            {
                decision.MostrarDecision();
            }
            else
            {
                Debug.LogWarning("❌ DecisionDia2 NO asignado en Luis");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
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

            if (indicadorE != null)
                indicadorE.SetActive(false);
        }
    }
}