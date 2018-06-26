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
    private float SpawnerStartHP;


    // Use this for initialization
    //resets spawn timer
    void Start()
    {
        SpawnerStartHP = SpawnerHP;
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

    //calls death function
    public void Damage(float Amt)
    {
        SpawnerHP -= Amt;
        if (SpawnerHP <= 0)
        {
            Death();
        }  
        SpawnerHpLVL();
        
    }

    //Death Function
    public void Death()
    {
        Destroy(gameObject);
    }

    //changes size of spawner dependent on health
    void SpawnerHpLVL()
    {

        if (SpawnerHP <= (SpawnerStartHP / 3 * 2) && SpawnerHP >= (SpawnerStartHP / 3))
        {
            transform.localScale -= new Vector3(50, 50, 50);
            //SpawnCount - 2; 
        }

        else if(SpawnerHP <= (SpawnerStartHP / 3) && SpawnerHP >= 1)
        {
            transform.localScale -= new Vector3(100, 100, 100);
        }
    }

}