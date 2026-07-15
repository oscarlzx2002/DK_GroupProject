using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public int targetFPS = 30;

    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
    void Start()
    {
        //Time.timeScale = 3f;
        //StartCoroutine(FreezeStart());
    }

    IEnumerator FreezeStart()
    {
        // Freeze the entire game
        Time.timeScale = 0f;

        // Wait for 3 real-world seconds
        yield return new WaitForSecondsRealtime(3f);

        // Resume the game
        Time.timeScale = 1f;
    }
}
