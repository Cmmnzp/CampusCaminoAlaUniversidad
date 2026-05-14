using UnityEngine;
using TMPro;

public class TutorialMovimiento : MonoBehaviour
{
    public GameObject panelTutorial;
    public TextMeshProUGUI texto;

    [Header("Jugador / Stats")]
    public PlayerStats stats;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoCompletar;

    private int paso = 0;
    public bool estaActivo = false;

    private bool finalizado = false;

    void Update()
    {
        if (!estaActivo) return;

        if (paso == 0)
        {
            texto.text = "Pulsa W para avanzar";
            if (Input.GetKeyDown(KeyCode.W)) paso++;
        }
        else if (paso == 1)
        {
            texto.text = "Pulsa S para retroceder";
            if (Input.GetKeyDown(KeyCode.S)) paso++;
        }
        else if (paso == 2)
        {
            texto.text = "Pulsa A para moverte a la izquierda";
            if (Input.GetKeyDown(KeyCode.A)) paso++;
        }
        else if (paso == 3)
        {
            texto.text = "Pulsa D para moverte a la derecha";
            if (Input.GetKeyDown(KeyCode.D)) paso++;
        }
        else if (paso == 4)
        {
            texto.text = "Mantén SHIFT + W para correr";
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) paso++;
        }
        else if (paso == 5)
        {
            texto.text = "Pulsa ESPACIO para saltar";
            if (Input.GetKeyDown(KeyCode.Space)) paso++;
        }
        else if (paso == 6)
        {
            texto.text = "Pulsa E para interactuar";
            if (Input.GetKeyDown(KeyCode.E)) paso++;
        }
        else if (paso == 7)
        {
            texto.text = "¡Bien hecho! Ya dominas los controles";

            if (!finalizado)
            {
                finalizado = true;

                DarRecompensa();

                if (audioSource && sonidoCompletar)
                    audioSource.PlayOneShot(sonidoCompletar);

                Invoke("FinalizarTutorial", 2f);
            }
        }
    }

    public void IniciarTutorial()
    {
        panelTutorial.SetActive(true);
        paso = 0;
        estaActivo = true;
        finalizado = false;
    }

    void DarRecompensa()
    {
        if (stats != null)
        {
            stats.AumentarConocimiento(10);
            stats.ReducirEstres(5);

            // 🔥 opcional si tienes relaciones
            if (stats.relaciones >= 0)
                stats.relaciones += 3;
        }

        Debug.Log("🎁 Recompensa del tutorial aplicada");
    }

    void FinalizarTutorial()
    {
        panelTutorial.SetActive(false);
        estaActivo = false;

        if (MissionManager.instancia != null)
        {
            MissionManager.instancia.SiguienteMision();
        }
    }
}