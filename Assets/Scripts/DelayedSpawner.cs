using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSpawner : EnemySpawner
{

    [SerializeField] private float startDelay = 5;


    public override void StartSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Invoke("SpawnObject", i * spawnInterval + startDelay);
        }
    }

}
