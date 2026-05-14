using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    public static DayManager instancia;

    public int diaActual = 1;
    public int totalDias = 7;

    public TextMeshProUGUI textoDia;
    public TextMeshProUGUI textoSemana;

    public GameObject[] dias;

    public GameObject npcLuis;
    public GameObject npcLaura;

    public UI_DiaAnimado uiAnimado;

    private string[] diasSemana =
    {
        "(Lunes)",
        "(Martes)",
        "(Miércoles)",
        "(Jueves)",
        "(Viernes)",
        "(Lunes)",
        "(Martes)"
    };

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        ActualizarTodo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SiguienteDia();

        if (Input.GetKeyDown(KeyCode.B))
            DiaAnterior();
    }

    public void SiguienteDia()
    {
        if (diaActual < totalDias)
        {
            diaActual++;

            ActualizarTodo();

            if (MissionManager.instancia != null)
                MissionManager.instancia.ActualizarMisionPorDia();

            Debug.Log("Día actual: " + diaActual);
        }
    }

    public void DiaAnterior()
    {
        if (diaActual > 1)
        {
            diaActual--;

            ActualizarTodo();

            if (MissionManager.instancia != null)
                MissionManager.instancia.ActualizarMisionPorDia();
        }
    }

    void ActualizarTodo()
    {
        ActualizarUI();
        ActualizarDias();
        ControlNPCs();
    }

    void ActualizarUI()
    {
        string textoDiaNuevo = "Día " + diaActual + " / " + totalDias;
        string textoSemanaNuevo = "";

        if (diaActual - 1 < diasSemana.Length)
            textoSemanaNuevo = diasSemana[diaActual - 1];

        if (uiAnimado != null)
        {
            uiAnimado.AnimarCambio(textoDiaNuevo, textoSemanaNuevo);
        }
        else
        {
            if (textoDia != null)
                textoDia.text = textoDiaNuevo;

            if (textoSemana != null)
                textoSemana.text = textoSemanaNuevo;
        }
    }

    void ActualizarDias()
    {
        for (int i = 0; i < dias.Length; i++)
        {
            if (dias[i] != null)
                dias[i].SetActive(i == diaActual - 1);
        }
    }

    void ControlNPCs()
    {
        if (npcLuis != null)
            npcLuis.SetActive(diaActual == 2);

        if (npcLaura != null)
            npcLaura.SetActive(diaActual == 3);
    }
}