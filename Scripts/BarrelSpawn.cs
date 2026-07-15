using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefabFall;
    [SerializeField] private GameObject barrelPrefabRoll;
    [SerializeField] private Transform[] spawnPoints;
    Transform chosenSpawner;

    public float spawnInterval = 3f;

    void Start()
    {
        //instantiate after seconds (menthod, delay after call, interval)
        InvokeRepeating( nameof(SpawnBarrel), 2f, spawnInterval);
    }
    void SpawnBarrel()
    {
        float chance = Random.value;

        // pick a random spawner
        // 80% chance spawning at Barrel_Roll_Spawn
        if (chance < 0.8f)
        {
            chosenSpawner = spawnPoints[0];
            Instantiate(barrelPrefabRoll, chosenSpawner.position, Quaternion.identity);

        }
        else
        {
            chosenSpawner = spawnPoints[1];
            // instantiate definition (object, spawn position, rotation)
            Instantiate(barrelPrefabFall, chosenSpawner.position, Quaternion.identity);

        }


        // instantiate definition (object, spawn position, rotation)
    }
}
