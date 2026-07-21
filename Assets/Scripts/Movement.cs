using UnityEngine;

public class Movement : MonoBehaviour
{

    //Floats
    public float climbSpeed;
    public float moveSpeed = 4.0f;
    public float jumpForce;

    public float horizontal;
    public float vertical;
    public float ladderX;
    public int Yspeed;

    public bool isClimbing;
    public bool isLadder;


    //Components
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject player;
    public BoxCollider2D bCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {

    }
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetInteger("Speed", (int)horizontal);

        anim.SetInteger("Yspeed", (int)vertical);
        //Flip sprite
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Jump();
        }
        

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        else
        {
            //Barrel.pE.rotationalOffset = 180f;
        }
    }
    void Jump()
    {
        // Apply immediate upward force using Impulse mode
        Debug.Log("Before: " + rb.linearVelocityY);
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("After" + rb.linearVelocityY);

        //rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * jumpForce);
    }
    private void FixedUpdate()
    {
        //Movement
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocityY);

        

        //Climb on zero gravity, else normal gravity
        if (isClimbing)
        {
            anim.speed = 0;
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, vertical * climbSpeed);
            player.transform.position = new Vector2(ladderX, rb.position.y);

        }
        else
        {
            if(!isClimbing)
            {
                anim.speed = 1;
                rb.gravityScale = 10f;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("EndClimb"))
        {
            anim.SetBool("Climb", false);
            isClimbing = false;
            player.transform.position = this.transform.position;
            bCollider.isTrigger = false;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            if (Input.GetKey(KeyCode.W))
            {
                isClimbing = true;
                anim.SetBool("Climb", true);
                bCollider.isTrigger = true;
                anim.speed = 1;
                rb.gravityScale = 0f;
                rb.linearVelocity = new Vector2(rb.linearVelocityX, vertical * climbSpeed);
                ladderX = collision.transform.position.x;
            }
        }
        else
        {
            
            if (vertical == 0 && collision.CompareTag("Ladder"))
            {
                anim.speed = 0;
                rb.gravityScale = 0f;

            }

            anim.speed = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            anim.SetBool("Climb", false);

            isLadder = false;
            isClimbing = false;

        }
    }

    //Grounded check
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }




}