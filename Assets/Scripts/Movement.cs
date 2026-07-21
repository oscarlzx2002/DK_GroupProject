using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour

{
    // Floats
    public float climbSpeed = 3.0f;
    public float moveSpeed = 4.0f;
    public float jumpForce = 5.0f;

    public float horizontal;
    public float vertical;
    public float ladderX;

    public bool isClimbing;
    public bool isLadder;

    // Components
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    public Transform groundCheck;
    public LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetInteger("Speed", (int)Mathf.Abs(horizontal));
        anim.SetInteger("Yspeed", (int)vertical);

        // Flip sprite
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }

        // Jump (Only when grounded and NOT climbing)
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isClimbing && !anim.GetBool("hasHammer"))
        {
            Jump();
        }

        // START CLIMBING: Triggered by pressing UP or DOWN while touching a ladder
        if (isLadder && Mathf.Abs(vertical) > 0f && !isClimbing)
        {
            StartClimbing();
        }

        // STOP CLIMBING: If Mario presses DOWN and reaches the solid floor platform
        if (isClimbing && vertical < 0f && IsGrounded())
        {
            StopClimbing();
        }
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;

            // Allow vertical climbing movement
            rb.linearVelocity = new Vector2(0f, vertical * climbSpeed);

            // Center Mario on ladder X
            rb.position = new Vector2(ladderX, rb.position.y);

            // Pause animation if player isn't moving on ladder
            anim.speed = (vertical != 0) ? 1f : 0f;
        }
        else
        {
            // Standard horizontal platform movement
            anim.speed = 1f;
            rb.gravityScale = 6f;
            rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocityY);
        }
    }

    private void StartClimbing()
    {
        isClimbing = true;
        anim.SetBool("Climb", true);

        // Disable player-ground collisions while on ladder
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), true);
    }

    private void StopClimbing()
    {
        isClimbing = false;
        anim.SetBool("Climb", false);
        anim.speed = 1f;

        // CRUCIAL: Re-enable ground collisions!
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            ladderX = collision.transform.position.x;
        }

        if (collision.CompareTag("EndClimb"))
        {
            StopClimbing();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            if (isClimbing)
            {
                StopClimbing();
            }
        }

        if (collision.CompareTag("EndClimb"))
        {
            StopClimbing();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (anim.GetBool("hasHammer") &&
            collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}