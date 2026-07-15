using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rb;

    public float fallSpeed = 5f;
    public float rollSpeed = 5f;

    private enum BarrelState
    {
        Falling,
        Rolling
    }
    private BarrelState currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
        /*switch (currentState)
        {
            case BarrelState.Falling:
                //FallLadder();
                break;

            case BarrelState.Rolling:
                break;
        }
    }
    void Falloff()
    {

    }
    /*void FallLadder()
    {
        transform.position = Vector2.MoveTowards(
           transform.position,
           pointB.position,
           fallSpeed * Time.deltaTime
       );


        if (Vector2.Distance(transform.position, pointB.position) < 0.05f)
        {
            StartRolling();
        }
    }*/

    void StartRolling()
    {
        // Enable physics
        rb.bodyType = RigidbodyType2D.Dynamic;


        rb.linearVelocity = new Vector2(
            rollSpeed,
            rb.linearVelocity.y
        );
    }
    void FixedUpdate()
    {
        if (currentState == BarrelState.Rolling)
        {
            rb.linearVelocity = new Vector2(
                rollSpeed,
                rb.linearVelocity.y
            );
        }
    }
}
