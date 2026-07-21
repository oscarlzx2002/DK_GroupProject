using UnityEngine;
using System;

public class LadderNumberGen : MonoBehaviour
{
    public int ladder4;
    public int ladder3;
    public int ladder2;
    public int ladder1;

    [Header("Regeneration Settings")]
    public float regenerateInterval = 5f;
    public bool regenerateOnStart = true;

    public static bool HasGenerated { get; private set; } = false;

    // Event that fires when numbers regenerate
    public static event Action OnNumbersRegenerated;

    void Start()
    {
        if (regenerateOnStart)
        {
            GenerateNumbers();
            HasGenerated = true;
            InvokeRepeating("RegenerateNumbers", regenerateInterval, regenerateInterval);
        }
    }

    void GenerateNumbers()
    {
        ladder4 = UnityEngine.Random.Range(8, 11);
        ladder3 = UnityEngine.Random.Range(6, 8);
        ladder2 = UnityEngine.Random.Range(3, 6);
        ladder1 = UnityEngine.Random.Range(1, 3);

        if (Contains5And9())
        {
            while (Contains5And9())
            {
                ladder4 = UnityEngine.Random.Range(8, 11);
                ladder3 = UnityEngine.Random.Range(6, 8);
                ladder2 = UnityEngine.Random.Range(3, 6);
                ladder1 = UnityEngine.Random.Range(1, 3);
            }
        }

        Debug.Log($"Ladder Numbers: {ladder1}, {ladder2}, {ladder3}, {ladder4}");
    }

    void RegenerateNumbers()
    {
        GenerateNumbers();
        Debug.Log($"Ladder numbers regenerated! Next in {regenerateInterval} seconds");

        // Notify all ladders to check their status
        OnNumbersRegenerated?.Invoke();
    }

    bool Contains5And9()
    {
        bool has5 = ladder1 == 5 || ladder2 == 5 || ladder3 == 5 || ladder4 == 5;
        bool has9 = ladder1 == 9 || ladder2 == 9 || ladder3 == 9 || ladder4 == 9;
        return has5 && has9;
    }
}