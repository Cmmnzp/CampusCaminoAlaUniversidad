using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    public static DayManager instancia; // 🔥 acceso global

    public int diaActual = 1;
    public int totalDias = 7;

    public TextMeshProUGUI textoDia;
    public TextMeshProUGUI textoSemana;

    public GameObject[] dias;

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
        instancia = this; // 🔥 importante
    }

    void Start()
    {
        ActualizarTodo();
    }

    void Update()
    {
        // 🔥 SOLO PARA PRUEBAS (puedes quitar luego)
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

            Debug.Log("Día actual: " + diaActual); // 🔍 debug útil
        }
    }

    public void DiaAnterior()
    {
        if (diaActual > 1)
        {
            diaActual--;
            ActualizarTodo();
        }
    }

    void ActualizarTodo()
    {
        ActualizarUI();
        ActualizarDias();
    }

    void ActualizarUI()
    {
        if (textoDia != null)
            textoDia.text = "Día " + diaActual + " / " + totalDias;

        if (textoSemana != null && diaActual - 1 < diasSemana.Length)
            textoSemana.text = diasSemana[diaActual - 1];
    }

    void ActualizarDias()
    {
        for (int i = 0; i < dias.Length; i++)
        {
            if (dias[i] != null)
                dias[i].SetActive(i == diaActual - 1);
        }
    }
}