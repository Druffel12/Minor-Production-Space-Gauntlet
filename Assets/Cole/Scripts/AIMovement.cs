using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public float Speed;
    public Transform Player;
    public Transform MyTransform;
    public float Range;
    Vector3 Dir;

    //set transform
    private void Awake()
    {
        MyTransform = transform;
    }
    // Use this for initialization
    //finding the player as to attack
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    //going after said player while looking at them and attacking 
    void Update()
    {

        GetComponent<NavMeshAgent>().destination = Player.position;

        Attack();
    }

    private void Attack()
    {
        if(Vector3.Distance(transform.position, Player.position) < Range)
        {
            //T set up damage application 
        }
    }
}
