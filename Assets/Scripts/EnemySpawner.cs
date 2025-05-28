using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject toSpawn;

    [SerializeField] protected int spawnCount = 3;

    [SerializeField] protected float spawnInterval = 2f;

    [SerializeField] private Transform target;
    // Start is called before the first frame update
    public virtual void Start()
    {
        StartSpawn();
    }

    public virtual void StartSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Invoke("SpawnObject", i * spawnInterval);
        }
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(toSpawn, transform.position, Quaternion.identity);
        Enemy enemy = spawnedObject.GetComponent<Enemy>();
        enemy.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
