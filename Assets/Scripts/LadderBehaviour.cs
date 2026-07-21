using UnityEngine;
using System.Collections;

public class LadderBehaviour : MonoBehaviour
{
    public int ladderNumber;

    void Start()
    {
        StartCoroutine(CheckAfterDelay());
    }

    IEnumerator CheckAfterDelay()
    {
        // Wait one frame to ensure LadderNumberGen has run
        yield return null;

        LadderNumberGen generator = FindFirstObjectByType<LadderNumberGen>();

        if (generator == null)
        {
            Debug.LogError("LadderNumberGen not found in scene!");
            yield break;
        }

        int[] randomNumbers = {
            generator.ladder1,
            generator.ladder2,
            generator.ladder3,
            generator.ladder4
        };

        bool isMatch = false;

        foreach (int num in randomNumbers)
        {
            if (ladderNumber == num)
            {
                isMatch = true;
                break;
            }
        }

        if (!isMatch)
        {
            gameObject.SetActive(false);
            Debug.Log($"Ladder {ladderNumber} disabled (not in random numbers)");
        }
    }
}