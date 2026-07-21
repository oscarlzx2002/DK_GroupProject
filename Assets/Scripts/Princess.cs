using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour

{
        public string winSceneName = "WinScene";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object touching this trigger is Mario / Player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the win zone! Loading: " + winSceneName);
            SceneManager.LoadScene(winSceneName);
        }
    }
}
