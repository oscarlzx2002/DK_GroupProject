using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefabRoll;

    [SerializeField] private Animator dKong;
    public GameObject spawner;
    public float spawnInterval = 5f;

    void Start()
    {
        //instantiate after seconds (menthod, delay after call, interval)
        InvokeRepeating( nameof(SpawnBarrel), 3f, spawnInterval);
        dKong = GetComponent<Animator>();
    }
    public void SpawnBarrel()
    {
        Debug.Log("Spawning Barrel");

        Instantiate(barrelPrefabRoll, spawner.transform.position, Quaternion.identity);
    }
    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnBarrel));
    }

    public void ResumeSpawning()
    {
        CancelInvoke(nameof(SpawnBarrel));
        InvokeRepeating(nameof(SpawnBarrel), spawnInterval, spawnInterval);
    }
}
