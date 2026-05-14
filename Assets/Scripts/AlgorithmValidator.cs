using UnityEngine;
using TMPro;

public class AlgorithmValidator : MonoBehaviour
{
    [Header("Slots")]
    public DropSlot slot1;

    public DropSlot slot2;

    public DropSlot slot3;

    public DropSlot slot4;

    public DropSlot slot5;

    [Header("UI")]
    public TextMeshProUGUI resultadoTexto;

    [Header("Panel Proyecto")]
    public GameObject panelProyecto;

    [Header("Sistemas")]
    public PlayerStats playerStats;

    public NPC_Felipe npcFelipe;

    [Header("Mateo D4")]
    public GameObject mateoD4;

    public void ValidarAlgoritmo()
    {
        bool correcto =
            slot1.currentBlock == "Inicio" &&
            slot2.currentBlock == "Leer" &&
            slot3.currentBlock == "Registrar" &&
            slot4.currentBlock == "Guardar" &&
            slot5.currentBlock == "Mostrar";

        if (correcto)
        {
            resultadoTexto.text =
                "ALGORITMO CORRECTO";

            resultadoTexto.color = Color.green;

            Debug.Log("Proyecto completado");

            if (playerStats != null)
            {
                playerStats.AumentarConocimiento(12);
            }

            if (MissionManager.instancia != null)
            {
                MissionManager.instancia.SetEstado(3);

                MissionManager.instancia.AsignarMision(
                    "Habla con Mateo"
                );
            }

            Invoke(nameof(CerrarProyectoCompleto), 2f);
        }
        else
        {
            resultadoTexto.text =
                "Orden incorrecto";

            resultadoTexto.color = Color.red;

            Debug.Log("Proyecto incorrecto");

            if (playerStats != null)
            {
                playerStats.AumentarEstres(5);
            }
        }
    }

    void CerrarProyectoCompleto()
    {
        if (panelProyecto != null)
        {
            panelProyecto.SetActive(false);
        }

        player jugador =
            FindFirstObjectByType<player>();

        if (jugador != null)
        {
            jugador.puedeMoverse = true;
        }

        if (mateoD4 != null)
        {
            mateoD4.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Puzzle Dia 4 cerrado correctamente");
    }
}