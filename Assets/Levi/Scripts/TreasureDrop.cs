using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDrop : MonoBehaviour
{
    
    ObjectPooler pool;
    public int dropRate;
    PickUpScript pickUp;

    public List<ObjectPooler> treasures = new List<ObjectPooler>();

    private void Start()
    {
        treasures.Add(ServiceLocator.instance.treasurePool1);
        treasures.Add(ServiceLocator.instance.treasurePool2);
        treasures.Add(ServiceLocator.instance.treasurePool3);
    }

    public void SpawnTreasure()
    {
        if(Random.Range(0,100) <= dropRate)
        {
            pool = treasures[Random.Range(0, treasures.Count)];
            GameObject spawnedObject = pool.GetPooledObject();
            pickUp = spawnedObject.GetComponent<PickUpScript>();
            pickUp.pool = pool;
            spawnedObject.transform.position = transform.position;

            //spawnedObject.transform.rotation = transform.rotation;

            spawnedObject.transform.parent = null;

            spawnedObject.SetActive(true);
        }
    }

}
