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
            conocimiento += 10;

        if (Input.GetKeyDown(KeyCode.H))
            conocimiento -= 10;

        if (Input.GetKeyDown(KeyCode.U))
            estres += 10;

        if (Input.GetKeyDown(KeyCode.J))
            estres -= 10;

        if (Input.GetKeyDown(KeyCode.I))
            relaciones += 5;

        if (Input.GetKeyDown(KeyCode.K))
            relaciones -= 5;
    }
}