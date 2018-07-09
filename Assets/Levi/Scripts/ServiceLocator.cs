using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour {

    public ObjectPooler enemyPool;
    public ObjectPooler enemyPool2;
    public ObjectPooler treasurePool;
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

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
