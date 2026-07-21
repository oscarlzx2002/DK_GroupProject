using UnityEngine;
using System.Collections;

public class PlayerSlow : MonoBehaviour
{
    private Movement movement;
    private bool isSlowed = false;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    public void SlowPlayer(float duration, float newSpeed)
    {
        if (!isSlowed)
        {
            StartCoroutine(SlowRoutine(duration, newSpeed));
        }
    }

    private IEnumerator SlowRoutine(float duration, float newSpeed)
    {
        isSlowed = true;

        float originalSpeed = movement.moveSpeed;

        movement.moveSpeed = newSpeed;

        Debug.Log("Mario Slowed!");

        yield return new WaitForSeconds(duration);

        movement.moveSpeed = originalSpeed;

        Debug.Log("Mario Speed Restored!");

        isSlowed = false;
    }
}
