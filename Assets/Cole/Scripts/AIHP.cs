using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour, IDamageable
{
    public float EnemyHP;
    public ObjectPooler MyPool;
    public float MaxHP;
    public EnemySpawner Spawner;
    Animator anim;
    TreasureDrop drop;

    private void Start()
    {
        MyPool = ObjectPooler.SharedInstance;
        MaxHP = EnemyHP;
        anim = GetComponent<Animator>();

        drop = GetComponent<TreasureDrop>();
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
        drop.SpawnTreasure();
        anim.SetBool("isDead", true);
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