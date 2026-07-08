using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class LadderSystem : MonoBehaviour
{
    public bool canclimb;
    public bool isclimbing;
    public float climbspeed = 4f;
    Movement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
           movement.rb.gravityScale = 0;
            movement.rb.linearVelocity = new Vector2
                (movement.rb.linearVelocity.x, vertical * climbspeed);
        }
        else
        {
            movement.rb.gravityScale = 9.8f;
        }
    }
}
