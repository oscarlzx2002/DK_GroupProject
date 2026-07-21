using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
    public void RetryGame()
    {
        // Reloads whichever scene is currently active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
