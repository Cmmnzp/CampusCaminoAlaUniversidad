using UnityEngine;

public class player : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float backSpeed = 1.5f;
    public float rotationSpeed = 120f;

    public bool hasKey = false;
    public bool puedeMoverse = true;

    [Header("Stats")]
    public PlayerStats stats;

    private Animator anim;
    private Rigidbody rb;

    float moveSpeed = 0f;

    private float energiaTimer = 0f;

    public float intervaloEnergia = 2.5f;

    void Start()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!puedeMoverse)
        {
            anim.SetInteger("states", 0);

            moveSpeed = 0;

            return;
        }

        int state = 0;

        bool corriendo =
            Input.GetKey(KeyCode.W) &&
            Input.GetKey(KeyCode.LeftShift);

        if (corriendo)
        {
            moveSpeed = runSpeed;

            state = 3;

            energiaTimer += Time.deltaTime;

            if (energiaTimer >= intervaloEnergia)
            {
                if (stats != null)
                {
                    stats.ReducirEnergia(2);
                }

                energiaTimer = 0f;
            }
        }
        else
        {
            energiaTimer = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                moveSpeed = walkSpeed;

                state = 2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveSpeed = -backSpeed;

                state = 4;
            }
            else
            {
                moveSpeed = 0;

                state = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = 6;
        }

        if (Input.GetKey(KeyCode.R))
        {
            state = 8;
        }

        if (stats != null && stats.energia <= 0)
        {
            moveSpeed *= 0.3f;
        }

        anim.SetInteger("states", state);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(
                0,
                rotationSpeed * Time.deltaTime,
                0
            );
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(
                0,
                -rotationSpeed * Time.deltaTime,
                0
            );
        }
    }

    void FixedUpdate()
    {
        if (!puedeMoverse)
            return;

        Vector3 movimiento =
            transform.forward *
            moveSpeed *
            Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movimiento);

        rb.linearVelocity =
            new Vector3(
                0,
                rb.linearVelocity.y,
                0
            );

        rb.angularVelocity = Vector3.zero;
    }
}