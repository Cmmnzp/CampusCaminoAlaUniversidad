using UnityEngine;

public class PlayerInteractionMateo : MonoBehaviour
{
    public GameObject mateoActual;
    public GameObject textoInteractuar;

    void Update()
    {
        if (mateoActual != null && Input.GetKeyDown(KeyCode.E))
        {
            mateoActual.GetComponent<NPCMateo>().Interactuar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mateo"))
        {
            mateoActual = other.gameObject;
            textoInteractuar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mateo"))
        {
            mateoActual = null;
            textoInteractuar.SetActive(false);
        }
    }
}