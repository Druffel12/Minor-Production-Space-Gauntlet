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
    public Transform Mesh;


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
                GameObject SpawnedBug2 = ServiceLocator.instance.enemyPool2.GetPooledObject();

                SpawnedBug.GetComponent<AIHP>().Spawner = this;
                SpawnedBug.SetActive(true);
                SpawnedBug.GetComponent<NavMeshAgent>().Warp(transform.position);

                SpawnedBug2.GetComponent<AIHP>().Spawner = this;
                SpawnedBug2.SetActive(true);
                SpawnedBug2.GetComponent<NavMeshAgent>().Warp(transform.position);

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
    }

    //Death Function
    public void Death()
    {
        Destroy(gameObject);
    }

    //T ask Kobey more efficient way to switch spawner states
    void SpawnerHpLVL()
    {
        if(SpawnerHP <= SpawnerStartHP && SpawnerHP >= (SpawnerStartHP/3 * 2))
        {
            //nothing really this if statement isactually redundant
        }

        else if(SpawnerHP <= (SpawnerHP/3 * 2) && SpawnerHP >= (SpawnerHP/3))
        {
            Mesh.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        }

        else
        {
            Mesh.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

}