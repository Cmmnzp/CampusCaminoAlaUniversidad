using UnityEngine;

public class NPC_Luis : MonoBehaviour
{
    public GameObject indicadorE;
    public GameObject panelDialogo;
    public DecisionDia2 decision;

    private bool jugadorCerca = false;
    private bool interaccionTerminada = false;

    void Start()
    {
        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }

    void Update()
    {
        if (interaccionTerminada)
            return;

        if (!jugadorCerca)
            return;

        if (indicadorE != null)
            indicadorE.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (indicadorE != null)
                indicadorE.SetActive(false);

            if (decision != null)
            {
                decision.MostrarDecision();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (interaccionTerminada)
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

            if (indicadorE != null)
                indicadorE.SetActive(false);
        }
    }

    public void OcultarNPC()
    {
        interaccionTerminada = true;

        if (indicadorE != null)
            indicadorE.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        gameObject.SetActive(false);
    }
}