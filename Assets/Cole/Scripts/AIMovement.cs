using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private Transform Player;
    private Transform MyTransform;
    public float Range;
    Vector3 Dir;
    private GameObject Target;

    //set transform
    private void Awake()
    {
        MyTransform = transform;
    }

    //trigger zone for finding player tags
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.transform;
            
        }
        else
        {
            Debug.Log("shits broken");
        }
    }

    // Update is called once per frame
    //going after said player while looking at them and attacking 
    void Update()
    {
        if (Player != null)
        {
            GetComponent<NavMeshAgent>().destination = Player.position;

            Attack();
        }
    }
    //Seeking and Attacking function
    private void Attack()
    {
        if(Vector3.Distance(transform.position, Player.position) < Range)
        {
            //T set up damage application 
        }
    }
   
}

