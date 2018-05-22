using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour, IDamageable
{
    public float EnemyHP;
    public ObjectPooler MyPool;

    public void Damage(float Amt)
    {
       EnemyHP -= Amt;
    }
    public void Death()
    {
        ReturnToPool();
    }
    public void ReturnToPool()
    {
        MyPool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
    }
}