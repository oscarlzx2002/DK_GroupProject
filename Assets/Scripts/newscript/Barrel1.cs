using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrel1 : MonoBehaviour
{
    private float rollspeed = 2f;
    private bool rotateSprite = true;
    private float rotationMultiplier = -500f;

    private Rigidbody2D rb;
    public float speed = 1f;
    private float direction = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }
    void Update()
    {
        if (direction != 0f)
        {
            transform.position += new Vector3(rollspeed * direction * Time.deltaTime, 0f, 0f);
        }

        if (rotateSprite)
        {
            transform.Rotate(0f, 0f, rollspeed * direction * rotationMultiplier * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlatformBool platformDir = collision.GetComponent<PlatformBool>();
        if (platformDir != null)
        {
            direction = platformDir.rollRight ? 1f : -1f;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get Mario's Animator (check both Mario and parent objects in case collider is on a child)
            Animator playerAnim = collision.gameObject.GetComponentInParent<Animator>();

            // Check if Mario is holding the hammer
            if (playerAnim != null && playerAnim.GetBool("hasHammer"))
            {
                // Hammer active -> Destroy the barrel!
                Destroy(gameObject);
            }
            else
            {
                // No hammer -> Mario dies / Level restarts
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
