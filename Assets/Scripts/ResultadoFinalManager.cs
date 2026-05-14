using UnityEngine;

public class ResultadoFinalManager : MonoBehaviour
{
    [Header("Paneles Finales")]

    public GameObject panelReprobado;

    public GameObject panelAprobadoBajo;

    public GameObject panelAprobado;

    public GameObject panelExcelente;

    
    public void MostrarResultadoFinal()
    {
        
        int puntaje =
            PlayerPrefs.GetInt(
                "PuntajeExamenFinal",
                0
            );

        if (panelReprobado != null)
            panelReprobado.SetActive(false);

        if (panelAprobadoBajo != null)
            panelAprobadoBajo.SetActive(false);

        if (panelAprobado != null)
            panelAprobado.SetActive(false);

        if (panelExcelente != null)
            panelExcelente.SetActive(false);

        if (puntaje <= 40)
        {
            if (panelReprobado != null)
            {
                panelReprobado.SetActive(true);
            }
        }

        else if (puntaje <= 59)
        {
            if (panelAprobadoBajo != null)
            {
                panelAprobadoBajo.SetActive(true);
            }
        }

        else if (puntaje <= 79)
        {
            if (panelAprobado != null)
            {
                panelAprobado.SetActive(true);
            }
        }

        else
        {
            if (panelExcelente != null)
            {
                panelExcelente.SetActive(true);
            }
        }

        
        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;
    }
}