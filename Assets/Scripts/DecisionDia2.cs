using UnityEngine;

public class DecisionDia2 : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelDecision;

    public GameObject panelJuntos;

    public GameObject panelSolo;

    [Header("Jugador")]
    public player jugador;

    public PlayerStats stats;

    [Header("Mateo")]
    public GameObject mateo;

    [Header("Texto Interactuar")]
    public GameObject textoInteractuarMateo;

    [Header("UI Animada")]
    public UI_DecisionAnimada uiAnimado;

    public void MostrarDecision()
    {
        if (jugador != null)
        {
            jugador.puedeMoverse = false;
        }

        if (uiAnimado != null)
        {
            uiAnimado.Mostrar();
        }
        else
        {
            if (panelDecision != null)
            {
                panelDecision.SetActive(true);
            }
        }

        Time.timeScale = 0f;
    }

    public void ElegirJuntos()
    {
        CerrarDecision();

        if (panelJuntos != null)
        {
            panelJuntos.SetActive(true);
        }
    }

    public void ElegirSolo()
    {
        CerrarDecision();

        if (panelSolo != null)
        {
            panelSolo.SetActive(true);
        }
    }

    public void ContinuarJuntos()
    {
        if (panelJuntos != null)
        {
            panelJuntos.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarRelaciones(25);
            stats.AumentarConocimiento(20);
            stats.ReducirEnergia(10);
            stats.ReducirEstres(5);
        }

        FinalizarDia("Estudiaste con Mateo");
    }

    public void ContinuarSolo()
    {
        if (panelSolo != null)
        {
            panelSolo.SetActive(false);
        }

        if (stats != null)
        {
            stats.AumentarConocimiento(30);
            stats.AumentarEstres(15);
            stats.ReducirEnergia(20);
        }

        FinalizarDia("Estudiaste solo");
    }

    void CerrarDecision()
    {
        if (uiAnimado != null)
        {
            uiAnimado.Ocultar();
        }
        else
        {
            if (panelDecision != null)
            {
                panelDecision.SetActive(false);
            }
        }
    }

    void FinalizarDia(string decision)
    {
        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        Time.timeScale = 1f;

        if (textoInteractuarMateo != null)
        {
            textoInteractuarMateo.SetActive(false);
        }

        if (mateo != null)
        {
            InteraccionNPC interaccion =
                mateo.GetComponent<InteraccionNPC>();

            if (interaccion != null)
            {
                interaccion.puedeInteractuar = false;

                if (interaccion.indicadorE != null)
                {
                    interaccion.indicadorE.SetActive(false);
                }
            }
        }

        if (DayEndManager.instancia != null)
        {
            DayEndManager.instancia.TerminarDia(decision);
        }

        Debug.Log("Dia 2 finalizado");
    }
}