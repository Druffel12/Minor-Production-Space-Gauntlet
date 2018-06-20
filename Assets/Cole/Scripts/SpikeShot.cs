using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShot : MonoBehaviour {

    public float SpikeDamage;
    public float SpikeLife;
    public ObjectPooler MyPool;
    public EnemySpawner Spawner;

    private void OnTriggerEnter(Collider other)
    {
        HP Temp = other.GetComponent<HP>();
        if(Temp != null)
        {
            Temp.Damage(SpikeDamage);
        }
   
    }

    private void Start()
    {
        MyPool = ObjectPooler.SharedInstance;
    }

    private void Update()
    {
        if (SpikeLife <= 0.0f)
        {
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        MyPool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
        if(Spawner != null)
        {
            Spawner.SpawnCount++;
        }
    }
}
