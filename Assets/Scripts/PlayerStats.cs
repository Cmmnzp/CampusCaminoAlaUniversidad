using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float energia = 100f;
    public float conocimiento = 50f;
    public float estres = 20f;
    public float relaciones = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ReducirEnergia(10);

        if (Input.GetKeyDown(KeyCode.T))
            AumentarEnergia(10);

        if (Input.GetKeyDown(KeyCode.Y))
            AumentarConocimiento(10);

        if (Input.GetKeyDown(KeyCode.H))
            ReducirConocimiento(10);

        if (Input.GetKeyDown(KeyCode.U))
            AumentarEstres(10);

        if (Input.GetKeyDown(KeyCode.J))
            ReducirEstres(10);

        if (Input.GetKeyDown(KeyCode.I))
            AumentarRelaciones(5);

        if (Input.GetKeyDown(KeyCode.K))
            ReducirRelaciones(5);
    }

    public void AumentarEnergia(float valor)
    {
        energia += valor;
        energia = Mathf.Clamp(energia, 0, 100);

        Debug.Log("+ Energía: " + energia);

        MostrarFeedback("+" + valor + " Energía", Color.yellow);

        ActualizarUI();
    }

    public void ReducirEnergia(float valor)
    {
        energia -= valor;
        energia = Mathf.Clamp(energia, 0, 100);

        Debug.Log("- Energía: " + energia);

        MostrarFeedback("-" + valor + " Energía", Color.red);

        ActualizarUI();
    }

    public void AumentarConocimiento(float valor)
    {
        conocimiento += valor;
        conocimiento = Mathf.Clamp(conocimiento, 0, 100);

        Debug.Log("+ Conocimiento: " + conocimiento);

        MostrarFeedback("+" + valor + " Conocimiento", Color.cyan);

        ActualizarUI();
    }

    public void ReducirConocimiento(float valor)
    {
        conocimiento -= valor;
        conocimiento = Mathf.Clamp(conocimiento, 0, 100);

        Debug.Log("- Conocimiento: " + conocimiento);

        MostrarFeedback("-" + valor + " Conocimiento", Color.red);

        ActualizarUI();
    }

    public void AumentarEstres(float valor)
    {
        estres += valor;
        estres = Mathf.Clamp(estres, 0, 100);

        Debug.Log("+ Estrés: " + estres);

        MostrarFeedback("+" + valor + " Estrés", Color.red);

        ActualizarUI();
    }

    public void ReducirEstres(float valor)
    {
        estres -= valor;
        estres = Mathf.Clamp(estres, 0, 100);

        Debug.Log("- Estrés: " + estres);

        MostrarFeedback("-" + valor + " Estrés", Color.green);

        ActualizarUI();
    }

    public void AumentarRelaciones(float valor)
    {
        relaciones += valor;
        relaciones = Mathf.Clamp(relaciones, 0, 100);

        Debug.Log("+ Relaciones: " + relaciones);

        MostrarFeedback("+" + valor + " Relaciones", Color.magenta);

        ActualizarUI();
    }

    public void ReducirRelaciones(float valor)
    {
        relaciones -= valor;
        relaciones = Mathf.Clamp(relaciones, 0, 100);

        Debug.Log("- Relaciones: " + relaciones);

        MostrarFeedback("-" + valor + " Relaciones", Color.red);

        ActualizarUI();
    }

    void MostrarFeedback(string mensaje, Color color)
    {
        if (StatsFeedbackUI.instancia != null)
        {
            StatsFeedbackUI.instancia.Mostrar(mensaje, color);
        }
    }

    void ActualizarUI()
    {
        if (BarsUI.instancia != null)
        {
            BarsUI.instancia.ActualizarBarras(
                energia,
                conocimiento,
                estres,
                relaciones
            );
        }
    }
}