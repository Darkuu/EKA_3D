using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : EnemySpawner
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          StartSpawn();  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
