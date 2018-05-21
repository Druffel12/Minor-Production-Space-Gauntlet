using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{


    public static float PlayerHealth = 100;
    public GameObject enemy;
    private float SpawnTime;
    public int SpawnCount;
    public Transform[] SpawnPoint;
    public float Spawner;
    public int Wave;


    // Use this for initialization
    //resets spawn timer
    void Start()
    {
        ResetTimer();
    }

    //enemy spawning loop 
    void Update()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0.0f)
        {
            if (SpawnCount > 0)
            {
                GameObject SpawnedBug = ObjectPooler.SharedInstance.GetPooledObject();

                SpawnedBug.SetActive(true);
                SpawnedBug.GetComponent<NavMeshAgent>().Warp(transform.position);


                if (SpawnCount > 0)
                {
                    SpawnCount--;
                }
                ResetTimer();
            }
        }
        
    }

    //resets enemy spawn timer funcion
    void ResetTimer()
    {
        SpawnTime = Spawner;
    }
}
