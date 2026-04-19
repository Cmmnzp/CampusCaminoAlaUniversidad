using UnityEngine;

public class player : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float backSpeed = 1.5f;
    public float rotationSpeed = 120f;
    public bool hasKey = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator no encontrado en este objeto.");
        }
    }

    void Update()
    {
        float moveSpeed = 0f;
        int state = 0;

        // BAILE 1
        if (Input.GetKeyDown(KeyCode.R))
        {
            state = 7;
        }


        // ATAQUE
        else if (Input.GetMouseButtonDown(0))
        {
            state = 5;
        }

        // SALTO
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            state = 6;
        }

        // CORRER
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            state = 3;
        }

        // CAMINAR
        else if (Input.GetKey(KeyCode.W))
        {
            moveSpeed = walkSpeed;
            state = 2;
        }

        // IR HACIA ATRÁS
        else if (Input.GetKey(KeyCode.S))
        {
            moveSpeed = -backSpeed;
            state = 4;
        }

        // IDLE
        else
        {
            state = 0;
        }

        anim.SetInteger("states", state);

        // MOVIMIENTO
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);

        // ROTACIÓN
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
}