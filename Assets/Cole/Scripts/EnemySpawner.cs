using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public static float PlayerHealth = 100;
    public GameObject enemy;
    private float spawnTime;
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
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0.0f)
        {
            if (SpawnCount > 0)
            {
                GameObject SpawnedBug = ObjectPooler.SharedInstance.GetPooledObject();

                SpawnedBug.SetActive(true);
                SpawnedBug.transform.position = transform.position;


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
        spawnTime = Spawner;
    }
}
