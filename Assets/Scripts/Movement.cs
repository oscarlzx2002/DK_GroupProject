using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

<<<<<<< Updated upstream
    public Rigidbody2D rb;
=======
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
>>>>>>> Stashed changes
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Face right
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Face left
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}