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
            energia -= 10;

        if (Input.GetKeyDown(KeyCode.T))
            energia += 10;

        if (Input.GetKeyDown(KeyCode.Y))
            AumentarConocimiento(10);

        if (Input.GetKeyDown(KeyCode.H))
            ReducirConocimiento(10);

        if (Input.GetKeyDown(KeyCode.U))
            AumentarEstres(10);

        if (Input.GetKeyDown(KeyCode.J))
            ReducirEstres(10);

        if (Input.GetKeyDown(KeyCode.I))
            relaciones += 5;

        if (Input.GetKeyDown(KeyCode.K))
            relaciones -= 5;
    }

    public void AumentarConocimiento(float valor)
    {
        conocimiento += valor;
        conocimiento = Mathf.Clamp(conocimiento, 0, 100);

        Debug.Log("+ Conocimiento: " + conocimiento);
    }

    public void ReducirConocimiento(float valor)
    {
        conocimiento -= valor;
        conocimiento = Mathf.Clamp(conocimiento, 0, 100);

        Debug.Log("- Conocimiento: " + conocimiento);
    }

    public void AumentarEstres(float valor)
    {
        estres += valor;
        estres = Mathf.Clamp(estres, 0, 100);

        Debug.Log("+ Estrés: " + estres);
    }

    public void ReducirEstres(float valor)
    {
        estres -= valor;
        estres = Mathf.Clamp(estres, 0, 100);

        Debug.Log("- Estrés: " + estres);
    }
}