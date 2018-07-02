using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour, IDamageable
{
    public float EnemyHP;
    public ObjectPooler MyPool;
    public float MaxHP;
    public EnemySpawner Spawner;
    public AIMovement AIMove;
    private GameObject damageEffect;
    public bool DamageTest;

    public ParticleSystem BugDmg;
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
        AIMove = GetComponent<AIMovement>();
        //damageEffect.SetActive(false);
    }

    void Update()
    {
        if(DamageTest == true)
        {
            DamageTest = false;
            Damage(0);
        }
    }

    public void Damage(float Amt)
    {
       
       EnemyHP -= Amt;
        if(BugDmg.isPlaying == false)
        {
            BugDmg.Play();
        }
        if(EnemyHP <= 0)
        {
            Death();
        }
        
        else
        {
            anim.SetTrigger("isShot");
        }
        if(AIMove.Player == null)
        {

            AIMove.findNearestPlayer(5);
        }

    }


    public void Death()
    {
        ReturnToPool();
        drop.SpawnTreasure();
        StopCoroutine(disable(0.17f));
        //damageEffect.SetActive(false);
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