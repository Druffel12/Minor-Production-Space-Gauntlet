using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDrop : MonoBehaviour
{
    
    ObjectPooler pool;
    public int dropRate = 20;
    PickUpScript pickUp;

    private void Start()
    {
        pool = ServiceLocator.instance.treasurePool;
    }

    public void SpawnTreasure()
    {
        if(Random.Range(0,100) <= dropRate)
        {
            GameObject spawnedObject = pool.GetPooledObject();
            pickUp = spawnedObject.GetComponent<PickUpScript>();
            pickUp.pool = pool;
            spawnedObject.transform.position = transform.position;

            spawnedObject.transform.rotation = transform.rotation;

            spawnedObject.transform.parent = null;

            spawnedObject.SetActive(true);
        }
    }

}
