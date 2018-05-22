using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler SharedInstance;
    [HideInInspector]
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;

    //make static later
    public int AmountToPool;

    //object activation check
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(ObjectToPool);
            obj.SetActive(false);
            obj.GetComponent<PooledObject>().myPool = this;
            PooledObjects.Add(obj);
        }
        return GetPooledObject();

    }
    //used for sharing code use
    void Awake()
    {
        SharedInstance = this;
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(ObjectToPool);
            obj.GetComponent<PooledObject>().myPool = this;
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }

}
