using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UIElements;
using TMPro;

public class FishMovement : MonoBehaviour
{
    [Header("Movimiento dentro del agua")]
    [SerializeField] private float swimSpeed = 4f;
    [SerializeField] private float swimMaxSpeed = 8f;
    [SerializeField] private string waterTag;

    [Header("Saltos fuera del agua")]
    [SerializeField] private float baseJumpForce = 6f;
    [SerializeField] private float jumpDamping = 0.6f;
    [SerializeField] private int maxJumps = 3;
    [SerializeField] private float horizontalDamping = 0.98f;
    private Rigidbody2D playerRigidbody2d;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.4f, 0.05f);
    [SerializeField] private LayerMask groundLayer;

    [Header("In Bucket")]
    private GameObject positionFish;
    [HideInInspector] public GameObject bucket;
    [SerializeField] private int timer;

    [Header("Rotation")]
    [SerializeField] private Transform playerSprite;
    [SerializeField] private float rotateThresholdVel = 0.0f;

    [Header("Particles")]
    [SerializeField] private ParticleSystem splashParticle;

    [Header("Audio")]
    [SerializeField] audiomanager audiomanager;

    private bool insideDrop;
    private Rigidbody2D rb;
    private Vector2 input = Vector2.zero;
    private bool isSwimming = false;
    private bool wasGroundedLastFrame = false;
    public int jumpCount = 0;
    private bool inBucket = false;
    private Animator animator;
    private bool isFacingRight = true;

    private void Awake()
    {
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        splashParticle.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed && insideDrop == false)
        {
            input = context.ReadValue<Vector2>();
            input.Normalize();
        }
        else if (context.canceled && insideDrop == false)
        {
            input = Vector2.zero;
        }
    }

    void Update()
    {
        animator.SetBool("isSwimming", isSwimming);


        if (isSwimming)
        {
            rb.gravityScale = 0;
            jumpCount = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity = input * swimMaxSpeed;
            }
            else
            {
                rb.linearVelocity = input * swimSpeed;
            }
        }
        else if (inBucket)
        {
            isSwimming = false;
            transform.position = positionFish.transform.position;
            playerSprite.localRotation = Quaternion.Euler(0f, 0f, -35f);
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
            jumpCount = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                inBucket = false;
                rb.AddForce(Vector2.up * jumpForce * 1.5f, ForceMode2D.Impulse);
                bucket.GetComponent<BucketController>().ReactivateCollider();
                playerSprite.localRotation = Quaternion.Euler(0f, 0f, 0f);
                SplashPartciles();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (bucket.tag == "derecha" || bucket.tag == "izquierda")
                {
                    inBucket = false;
                    bucket.GetComponent<BucketController>().PushRight();
                    rb.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
                    playerSprite.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    SplashPartciles();
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (bucket.tag == "derecha" || bucket.tag == "izquierda")
                {
                    inBucket = false;
                    bucket.GetComponent<BucketController>().PushLeft();
                    rb.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
                    playerSprite.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    SplashPartciles();
                }
            }
        }
        else
        {
            rb.gravityScale = 1f;
            bool grounded = IsGrounded();

            if (grounded && !wasGroundedLastFrame)
            {
                if (jumpCount < maxJumps && !isSwimming)
                {
                    audiomanager.PlaySFX(audiomanager.jump);
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumpCount++;
                }
                else
                {
                    Death();
                }
            }

            wasGroundedLastFrame = grounded;

            if (jumpCount < maxJumps)
            {
                rb.linearVelocity = new Vector2(swimSpeed * input.x * horizontalDamping, rb.linearVelocity.y);
            }
        }

        RotatePlayer(rb.linearVelocity);
    }

    private IEnumerator Reiniciar(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SplashPartciles()
    {
        splashParticle.gameObject.SetActive(false);
        splashParticle.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(waterTag))
            isSwimming = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag) || inBucket)
        {
            SplashPartciles();
            audiomanager.PlaySFX(audiomanager.splash);
        }
        else if (collision.CompareTag("muerte"))
        {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 1f;
            audiomanager.PlaySFX(audiomanager.death);
            animator.SetTrigger("dead2");
            StartCoroutine(Reiniciar(2.0f));
        }
        else if (collision.tag == "drops")
        {
            jumpCount = 0;
            insideDrop = true;
            transform.SetParent(collision.transform);
            rb.linearVelocity = collision.GetComponent<Rigidbody2D>().linearVelocity;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            isSwimming = false;
            SplashPartciles();
            audiomanager.PlaySFX(audiomanager.splash);
        }
    }

    public void SetDrops(bool state)
    {
        insideDrop = state;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, groundLayer) != null;
    }

    private void RotatePlayer(Vector2 vel)
    {
        if (vel.magnitude < 0.01f) return;

        bool facingRight = vel.x >= 0;
        playerSprite.localScale = new Vector3(facingRight ? 1f : -1f, 1f, 1f);

        float tiltAngle = Mathf.Clamp(vel.y * 10f, -45f, 45f);

        if (!facingRight)
            tiltAngle = -tiltAngle;

        playerSprite.localRotation = Quaternion.Lerp(
            playerSprite.localRotation,
            Quaternion.Euler(0f, 0f, tiltAngle),
            0.1f
        );
    }

    public bool GetBucket()
    {
        return inBucket;
    }

    public void SetBucket(bool bucket)
    {
        inBucket = bucket;
    }

    public void SetBucket(GameObject bck)
    {
        bucket = bck;
    }

    public void SetFishPosition(GameObject fishPos)
    {
        positionFish = fishPos;
    }

    public void Death()
    {
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 1f;
        audiomanager.PlaySFX(audiomanager.death);
        animator.SetTrigger("dead");
        StartCoroutine(Reiniciar(2.0f));
    }

    private void OnDrawGizmos()
    {
        if (groundCheckPos == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}