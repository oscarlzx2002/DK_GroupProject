using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrel : MonoBehaviour
{
    protected Rigidbody2D rb;

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

    }
}