using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour {

    public ObjectPooler enemyPool;
    public ObjectPooler enemyPool2;
    public ObjectPooler treasurePool1;
    public ObjectPooler treasurePool2;
    public ObjectPooler treasurePool3;
    public static ServiceLocator instance;
    // Use this for initialization

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else { Destroy(this); }
    }
}
