using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class LadderSystem : MonoBehaviour
{
    public bool canclimb;
    public bool isclimbing;
    public float climbspeed = 4f;
    Rigidbody2D rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        if (canclimb && Mathf.Abs(vertical) > 0.6f) ;
        {
            isclimbing = true;
        }
        if (isclimbing)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2
                (rb.linearVelocity.x, vertical * climbspeed);
        }
        else
        {
            rb.gravityScale = normalGravity;
        }
    }
}
