using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Player hit: {collision.gameObject.name} with tag: {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("barrel"))
        {
            Debug.Log("Player hit barrel! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}