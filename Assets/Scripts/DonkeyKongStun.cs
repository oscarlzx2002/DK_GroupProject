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

        StartCoroutine(StunRoutine());
    }

    private IEnumerator StunRoutine()
    {
        stunned = true;

        Debug.Log("Donkey Kong Stunned for 20 seconds!");

        barrelSpawn.StopSpawning();

        yield return new WaitForSeconds(20f);

        Debug.Log("Donkey Kong Recovered!");

        barrelSpawn.ResumeSpawning();

        stunned = false;
    }
}