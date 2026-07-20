using UnityEngine;
using System.Collections;

public class DonkeyKongStun : MonoBehaviour
{
    private BarrelSpawn barrelSpawn;
    private bool isStunned = false;

    private void Start()
    {
        barrelSpawn = GetComponent<BarrelSpawn>();
    }

    public void Stun(float duration)
    {
        if (!isStunned)
        {
            StartCoroutine(StunCoroutine(duration));
        }
    }

    IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;

        // Disable the barrel spawning script
        barrelSpawn.enabled = false;

        Debug.Log("Donkey Kong is stunned!");

        yield return new WaitForSeconds(duration);

        // Enable it again
        barrelSpawn.enabled = true;

        isStunned = false;

        Debug.Log("Donkey Kong recovered!");
    }
}
