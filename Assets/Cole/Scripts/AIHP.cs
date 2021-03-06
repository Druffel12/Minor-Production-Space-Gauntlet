﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour, IDamageable
{
    public float EnemyHP;
    public ObjectPooler MyPool;
    public float MaxHP;
    public EnemySpawner Spawner;

    public GameObject damageEffect;

    Animator anim;
    TreasureDrop drop;

    IEnumerator disable(float t)
    {
        yield return new WaitForSeconds(t);
        damageEffect.SetActive(false);
    }


    private void Start()
    {
        MyPool = ObjectPooler.SharedInstance;
        MaxHP = EnemyHP;
        anim = GetComponent<Animator>();
        drop = GetComponent<TreasureDrop>();
        damageEffect.SetActive(false);
    }


    public void Damage(float Amt)
    {
       EnemyHP -= Amt;
        if(gameObject.activeInHierarchy)
        {
            damageEffect.SetActive(true);
            StartCoroutine(disable(0.17f));
        }
        if(EnemyHP <= 0)
        {
            Death();
        }
    
    }


    public void Death()
    {
        ReturnToPool();
        drop.SpawnTreasure();
        StopCoroutine(disable(0.17f));
        damageEffect.SetActive(false);
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