using UnityEngine;
using System.Collections;

public class LadderBehaviour : MonoBehaviour
{
    public int ladderNumber;
    private bool isDisabled = false;
    private LadderNumberGen generator;

    void Start()
    {
        generator = FindFirstObjectByType<LadderNumberGen>();

        if (generator == null)
        {
            Debug.LogError("LadderNumberGen not found in scene!");
            return;
        }

        // Subscribe to regeneration event
        LadderNumberGen.OnNumbersRegenerated += CheckLadder;

        // Wait one frame before checking
        StartCoroutine(DelayedCheck());
    }

    IEnumerator DelayedCheck()
    {
        yield return null;
        CheckLadder();
    }

    void CheckLadder()
    {
        if (generator == null)
        {
            generator = FindFirstObjectByType<LadderNumberGen>();
            if (generator == null)
            {
                Debug.LogError("LadderNumberGen not found in scene!");
                return;
            }
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

        if (isMatch)
        {
            if (isDisabled)
            {
                gameObject.SetActive(true);
                isDisabled = false;
                Debug.Log($"Ladder {ladderNumber} re-enabled");
            }
        }
        else
        {
            gameObject.SetActive(false);
            isDisabled = true;
            Debug.Log($"Ladder {ladderNumber} disabled");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        LadderNumberGen.OnNumbersRegenerated -= CheckLadder;
    }
}