using UnityEngine;
using TMPro;
using System.Collections;

public class MateoMovement : MonoBehaviour
{
    public Transform destino;
    public Transform jugador;

    public float velocidad = 2f;
    public float distanciaMax = 5f;

    public TextMeshProUGUI textoMateo;
    public GameObject profesor;

    public TutorialMovimiento tutorial;
    public InteraccionNPC interaccion;

    private Animator anim;
    private bool moviendo = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (textoMateo != null)
            textoMateo.gameObject.SetActive(false);
    }

    void Update()
    {
        if (moviendo && destino != null)
        {
            float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

            // 🔴 Si el jugador se aleja
            if (distanciaJugador > distanciaMax)
            {
                anim.SetBool("caminar", false);

                if (textoMateo != null && (tutorial == null || !tutorialActivo()))
                {
                    textoMateo.gameObject.SetActive(true);
                    textoMateo.text = "¡Ey! No te quedes atrás";
                }

                return;
            }

            // 🟢 Reactivar animación
            if (!anim.GetBool("caminar"))
                anim.SetBool("caminar", true);

            // 🔵 Texto mientras camina
            if (textoMateo != null && (tutorial == null || !tutorialActivo()))
            {
                textoMateo.gameObject.SetActive(true);
                textoMateo.text = "Sígueme, te mostraré el aula";
            }

            // 🟡 Movimiento
            Vector3 direccion = (destino.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;

            Vector3 lookPos = new Vector3(destino.position.x, transform.position.y, destino.position.z);
            transform.LookAt(lookPos);

            float distancia = Vector3.Distance(transform.position, destino.position);

            // 🟣 Llegada al destino
            if (distancia < 0.5f)
            {
                moviendo = false;
                anim.SetBool("caminar", false);

                // 🔥 AVANZAR MISIÓN
                if (MissionManager.instancia != null)
                {
                    MissionManager.instancia.SiguienteMision();
                }

                // 👉 Mirar al jugador
                Vector3 mirarJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
                transform.LookAt(mirarJugador);

                // 🔥 MENSAJE FINAL
                if (textoMateo != null)
                {
                    textoMateo.gameObject.SetActive(true);
                    textoMateo.text = "Esta es el aula de clases. Ahora habla con el profesor.";

                    Invoke("OcultarMensajeFinal", 4f);
                }

                // 👉 Activar profesor
                if (profesor != null)
                    profesor.SetActive(true);
            }
        }
    }

    public void EmpezarMovimiento()
    {
        if (destino == null || jugador == null)
        {
            Debug.LogWarning("Falta asignar destino o jugador");
            return;
        }

        // 🔴 Desactivar interacción con Mateo
        if (interaccion != null)
        {
            interaccion.puedeInteractuar = false;
        }

        StartCoroutine(MirarYCaminar());
    }

    IEnumerator MirarYCaminar()
    {
        // 👉 Mira al jugador antes de moverse
        Vector3 lookPos = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        transform.LookAt(lookPos);

        yield return new WaitForSeconds(1.5f);

        anim.SetBool("caminar", true);
        moviendo = true;

        // 🔥 Inicia tutorial
        if (tutorial != null)
        {
            tutorial.IniciarTutorial();

            if (textoMateo != null)
                textoMateo.gameObject.SetActive(false);
        }
    }

    void OcultarMensajeFinal()
    {
        if (textoMateo != null)
            textoMateo.gameObject.SetActive(false);
    }

    bool tutorialActivo()
    {
        return tutorial != null && tutorial.estaActivo;
    }
}