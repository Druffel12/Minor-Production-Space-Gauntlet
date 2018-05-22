﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private Transform Player;
    private Transform MyTransform;
    public float Range;
    public float searchRange;
    Vector3 Dir;
    //private GameObject Target;
    public int EnemyHP;
    public float thoughtDelay;
    float thoughtTimer;
    //set transform
    private void Awake()
    {
        MyTransform = transform;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRange);
    }

    //trigger zone for finding player tags
    Transform findNearestPlayer()
    {
        Transform retval = null;
        Collider[] neighbours = Physics.OverlapSphere(transform.position, searchRange, 1 << 9);
        float min = Mathf.Infinity;
        foreach(Collider guy in neighbours)
        {
            float distance = Vector3.Distance(transform.position, guy.transform.position);
            if(distance <= min)
            {
                retval = guy.transform;
            }
        }
        //Debug.Log(retval.gameObject.name);
        return retval;
    }

    // Update is called once per frame
    //going after said player while looking at them and attacking 
    void Update()
    {
        thoughtTimer -= Time.deltaTime;
        if(thoughtTimer <= 0 && Player == null)
        {
            Player = findNearestPlayer();
            thoughtTimer = thoughtDelay;
        }
        
        if (Player != null)
        {
            GetComponent<NavMeshAgent>().destination = Player.position;
            Debug.DrawLine(transform.position, Player.transform.position);
            Attack();
        }
    }
    //Seeking and Attacking function
    private void Attack()
    {
        if(Vector3.Distance(transform.position, Player.position) < Range)
        {
            //T
        }
    }
   
}

