using UnityEngine;

public class LockSpriteRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Save the sprite's starting rotation angle
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Reapply the original rotation every single frame
        transform.rotation = initialRotation;
    }
}
