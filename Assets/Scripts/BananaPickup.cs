using UnityEngine;

public class BananaPickup : MonoBehaviour
{
    [SerializeField] private DonkeyKongStun donkeyKong;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            donkeyKong.Stun(5f);

            Destroy(gameObject);
        }
    }
}