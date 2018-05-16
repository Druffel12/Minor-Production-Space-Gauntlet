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
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0.0f)
        {
            if (SpawnCount > 0)
            {
                // (enemy, transform.position, Quaternion.identity);
                GameObject SpawnedDeer = ObjectPooler.SharedInstance.GetPooledObject();

                SpawnedDeer.SetActive(true);
                SpawnedDeer.transform.position = transform.position;




                //implement wave system

                if (SpawnCount > 0)
                {
                    SpawnCount--;
                }
                ResetTimer();
            }
        }
        //player days 
        if (PlayerHealth == 0)
        {
            Application.Quit();
        }
    }

    void ResetTimer()
    {
        spawnTime = Spawner;
    }
}
