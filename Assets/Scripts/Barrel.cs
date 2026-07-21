using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Barrel : MonoBehaviour
{
    /*protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Movement p))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }*/

    protected Rigidbody2D rb;
    public float speed = 1f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Push barrels in the direction the platform is facing.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
            return;
        }

        // Restart the scene if the player is hit.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}