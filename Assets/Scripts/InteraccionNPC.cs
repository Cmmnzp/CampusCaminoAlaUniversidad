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
        if (!puedeInteractuar)
        {
            if (indicadorE != null)
                indicadorE.SetActive(false);

            return;
        }

        if (jugadorCerca)
        {
            if (indicadorE != null)
                indicadorE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (panelDialogo != null)
                    panelDialogo.SetActive(true);
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

            if (panelDialogo != null)
                panelDialogo.SetActive(false);
        }
    }

    public void BotonSi()
    {
        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        MateoMovement mateo = GetComponent<MateoMovement>();

        if (mateo != null)
        {
            mateo.EmpezarMovimiento();
        }
    }

    public void BotonNo()
    {
        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }
}