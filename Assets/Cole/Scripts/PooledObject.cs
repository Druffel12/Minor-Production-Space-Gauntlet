using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPooler myPool;

    public void ReturnToPool()
    {
        myPool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}
