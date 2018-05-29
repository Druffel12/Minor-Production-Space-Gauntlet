using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour, IDamageable
{
    public float EnemyHP;
    public ObjectPooler MyPool;
    public float MaxHP;
    public EnemySpawner Spawner;

    private void Start()
    {
        MyPool = ObjectPooler.SharedInstance;
        MaxHP = EnemyHP;
    }
    public void Damage(float Amt)
    {
       EnemyHP -= Amt;
        if(EnemyHP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        ReturnToPool();

        EnemyHP = MaxHP;
    }
    public void ReturnToPool()
    {
        MyPool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
        if(Spawner != null)
        {
            Spawner.SpawnCount++;
        }
    }
}