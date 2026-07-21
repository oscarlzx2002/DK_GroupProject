using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefabRoll;

    [SerializeField] private Animator dKong;
    public GameObject spawner;
    public float spawnInterval = 3f;

    void Start()
    {
        //instantiate after seconds (menthod, delay after call, interval)
        InvokeRepeating( nameof(SpawnBarrel), 2f, spawnInterval);
        dKong = GetComponent<Animator>();
    }
    public void SpawnBarrel()
    {

        Instantiate(barrelPrefabRoll, spawner.transform.position, Quaternion.identity);
    }
}
