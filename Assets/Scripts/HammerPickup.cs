using System.Collections;
using UnityEngine;

public class HammerPickup : MonoBehaviour
{
    [SerializeField] private float powerUpDuration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;


        Movement playerMovement = collision.GetComponent<Movement>();
        Animator playerAnimator = collision.GetComponent<Animator>();

        if (playerMovement != null && playerAnimator != null)
        {
            playerMovement.StartCoroutine(HammerTimer(playerAnimator));
        }

        GetComponent<Collider2D>().enabled = false;
        if (GetComponent<Renderer>() != null) GetComponent<Renderer>().enabled = false;

        Destroy(gameObject, powerUpDuration);
    }

    private IEnumerator HammerTimer(Animator animator)
    {
        animator.SetBool("hasHammer", true);
        yield return new WaitForSeconds(powerUpDuration);
        animator.SetBool("hasHammer", false);
    }
}
