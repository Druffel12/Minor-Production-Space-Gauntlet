using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour, IDamageable
{

    private float SpawnTime;
    public int SpawnCount;
    public float Spawner;
    public float SpawnerHP;
    public float SpawnFB;
    public float SpawnLR;

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
                GameObject SpawnedBug = ServiceLocator.instance.enemyPool.GetPooledObject();

                SpawnedBug.GetComponent<AIHP>().Spawner = this;
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

    public void Damage(float Amt)
    {
        SpawnerHP -= Amt;
        if (SpawnerHP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
