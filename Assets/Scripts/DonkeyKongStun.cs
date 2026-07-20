using UnityEngine;
using System.Collections;

public class DonkeyKongStun : MonoBehaviour
{
    private BarrelSpawn barrelSpawn;
    private bool stunned = false;

    private void Awake()
    {
        barrelSpawn = GetComponent<BarrelSpawn>();
    }

    public void Stun(float duration)
    {
        if (stunned)
            return;

        StartCoroutine(StunRoutine(duration));
    }

    IEnumerator StunRoutine(float duration)
    {
        stunned = true;

        Debug.Log("Donkey Kong Stunned!");

        // Stop spawning barrels
        barrelSpawn.CancelInvoke();

        // Wait 5 seconds
        yield return new WaitForSeconds(duration);

        Debug.Log("Donkey Kong Recovered!");

        // Start spawning again
        barrelSpawn.InvokeRepeating(nameof(BarrelSpawn.SpawnBarrel), 0f, barrelSpawn.spawnInterval);

        stunned = false;
    }
}
