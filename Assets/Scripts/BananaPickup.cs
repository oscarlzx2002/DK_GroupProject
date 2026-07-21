using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    [SerializeField] private float slowDuration = 6f;
    [SerializeField] private float slowedSpeed = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Banana Picked Up!");

            PlayerSlow playerSlow = collision.GetComponent<PlayerSlow>();

            if (playerSlow != null)
            {
                playerSlow.SlowPlayer(slowDuration, slowedSpeed);
            }

            Destroy(gameObject);
        }
    }
}