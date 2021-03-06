﻿using System.Collections;
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
            if(PooledObjects[i] == null)
            {
                PooledObjects.RemoveAt(i);
                i--;
                continue;
            }
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        //pooling logic
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(ObjectToPool);
            obj.SetActive(false);
            PooledObject cache = obj.GetComponent<PooledObject>();
            if(cache != null) { cache.myPool = this; }
            PooledObjects.Add(obj);
        }
        return GetPooledObject();

    }
    //used for sharing code
    void Awake()
    {
        SharedInstance = this;
        PooledObjects = new List<GameObject>();
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(ObjectToPool);
            PooledObject cache = obj.GetComponent<PooledObject>();
            if (cache != null) { cache.myPool = this; }
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }

}
