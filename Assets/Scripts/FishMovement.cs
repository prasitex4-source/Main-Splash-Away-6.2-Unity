using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    [Header("Movimiento dentro del agua")]
    [SerializeField] private float swimSpeed = 4f;
    [SerializeField] private string waterTag;

    [Header("Saltos fuera del agua")]
    [SerializeField] private float baseJumpForce = 6f;      // Fuerza del primer salto
    [SerializeField] private float jumpDamping = 0.6f;       // Reducción progresiva de fuerza
    [SerializeField] private int maxJumps = 3;               // Número exacto de saltos
    [SerializeField] private float horizontalDamping = 0.98f;// Damping horizontal por frame
    private Rigidbody2D playerRigidbody2d; //Rigidbody of the player to apply forces and movement.

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f; //Force used to jump.

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPos;       // Hijo bajo el pez
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.4f, 0.05f);
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 input = Vector2.zero;
    private bool isSwimming = false;
    private bool wasGroundedLastFrame = false;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Asegúrate de desmarcar Freeze Rotation en Z en el Rigidbody2D
    }

    // Entrada del nuevo Input System
    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            input = context.ReadValue<Vector2>();
            input.Normalize();
        }
        else if (context.canceled)
        {
            input = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (isSwimming)
        {
            // Movimiento libre dentro del agua
            rb.gravityScale = 0.1f;
            rb.linearVelocity = input * swimSpeed;
            jumpCount = 0; // Reinicia saltos al volver al agua
        }
        else
        {
            rb.gravityScale = 1f;
            bool grounded = IsGrounded();

            // Detecta contacto con el suelo
            if (grounded && !wasGroundedLastFrame)
            {
                if (jumpCount < maxJumps)
                {

                    // Resetea la velocidad vertical antes de aplicar salto
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    jumpCount++;
                }
                else
                {
                    // Después del último salto, se detiene
                    rb.linearVelocity = Vector2.zero;
                    rb.gravityScale = 1f;
                }
            }

            wasGroundedLastFrame = grounded;

            if (jumpCount < maxJumps)// Damping horizontal configurable
            {
                rb.linearVelocity = new Vector2(swimSpeed * input.x * horizontalDamping, rb.linearVelocityY);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(waterTag))
            isSwimming = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(waterTag))
            isSwimming = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, groundLayer) != null;
    }

    private void OnDrawGizmos()
    {
        if (groundCheckPos == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
