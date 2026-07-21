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
        else if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }





        /* Push barrels in the direction the platform is facing.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
            return;
        }

        // Restart the scene if the player is hit.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }




}
