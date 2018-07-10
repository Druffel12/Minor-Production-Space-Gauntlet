using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShot : MonoBehaviour {

    public float SpikeDamage;
    public float SpikeLife;
    public ObjectPooler MyPool;
    public EnemySpawner Spawner;

    //checks collision
    private void OnTriggerEnter(Collider other)
    {
        HP Temp = other.GetComponent<HP>();
        if(Temp != null)
        {
            Temp.Damage(SpikeDamage);
        }
   
    }

    //pool connecting
    private void Start()
    {
        MyPool = ObjectPooler.SharedInstance;
    }

    //life of spike
    private void Update()
    {
        SpikeLife -= Time.deltaTime; 
        if (SpikeLife <= 0.0f)
        {
            ReturnToPool();
        }
    }

    //return to pool
    void ReturnToPool()
    {
        MyPool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}
