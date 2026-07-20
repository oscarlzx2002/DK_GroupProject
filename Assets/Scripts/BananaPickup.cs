using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    [SerializeField] private DonkeyKongStun donkeyKong;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Banana Picked Up!");

            donkeyKong.Stun(5f);

            Destroy(gameObject);
        }
    }
}