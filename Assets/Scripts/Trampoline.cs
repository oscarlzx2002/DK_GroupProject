using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 12f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            if (rb != null)
            {
                float incomingSpeed = Mathf.Abs(rb.linearVelocity.y);
                Vector2 velocity = rb.linearVelocity;
                velocity.y = 0f;
                rb.linearVelocity = velocity;
                float finalForce = Mathf.Max(bounceForce, incomingSpeed * 1.5f);
                rb.AddForce(Vector2.up * finalForce, ForceMode2D.Impulse);
            }
        }
    }
}
