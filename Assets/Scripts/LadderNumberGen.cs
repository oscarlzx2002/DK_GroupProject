using UnityEngine;

public class LadderNumberGen : MonoBehaviour
{
    public int ladder4;
    public int ladder3;
    public int ladder2;
    public int ladder1;

    void Start()
    {
        GenerateNumbers();
    }

    void GenerateNumbers()
    {
        // Generate ladder1 and ladder2 first (they can't be 5 or 9 based on ranges)
        ladder1 = Random.Range(1, 3); // 1 or 2
        ladder2 = Random.Range(3, 6); // 3, 4, or 5

        // Generate ladder3 (range 5-8 - can be 5)
        ladder3 = Random.Range(5, 8); // 5, 6, or 7

        // Generate ladder4 (range 8-11 - can be 9)
        ladder4 = Random.Range(8, 11); // 8, 9, or 10

        // If ladder3 is 5, make sure ladder4 is NOT 9
        if (ladder3 == 5)
        {
            // Regenerate ladder4 until it's not 9
            while (ladder4 == 9)
            {
                ladder4 = Random.Range(8, 11);
            }
        }
        // If ladder4 is 9, make sure ladder3 is NOT 5
        else if (ladder4 == 9)
        {
            // Regenerate ladder3 until it's not 5
            while (ladder3 == 5)
            {
                ladder3 = Random.Range(5, 8);
            }
        }

        Debug.Log($"Ladder Numbers: {ladder1}, {ladder2}, {ladder3}, {ladder4}");
    }
}