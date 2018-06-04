using System.Collections;
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
    public float thoughtDelay;
    float thoughtTimer;
    public GameObject AttackCube;
    public bool isAttacking;
    public bool isRunning;
    Animator anim;
    NavMeshAgent agent;

    //set transform
    private void Awake()
    {
        MyTransform = transform;
        AttackCube.SetActive(false);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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
        return retval;
    }

    // Update is called once per frame
    //going after said player while looking at them
    void Update()
    {
        thoughtTimer -= Time.deltaTime;
        if(thoughtTimer <= 0 )
        {
            Player = findNearestPlayer();
            if(Player != null)
            {
                agent.isStopped = false;
            }
            thoughtTimer = thoughtDelay;
        }
        
        if (Player != null)
        {
            if (Player.gameObject.activeInHierarchy)
            {
                agent.destination = Player.position;
                anim.SetBool("isRunning", true);

                Debug.DrawLine(transform.position, Player.transform.position);
                Attack();
            }
            else
            {
                Player = null;
                anim.SetBool("isRunning", false);
                agent.isStopped = true;
                anim.SetTrigger("isIdle");
            }
        }
    }
    //Seeking and Attacking function
    private void Attack()
    {
        if(Vector3.Distance(transform.position, Player.position) < Range && !isAttacking)
        {
            anim.SetTrigger("isAttacking");
            isAttacking = true;
            Debug.Log("Attack Cube on");
        }
    }

    public void enableCube()
    {
        AttackCube.SetActive(true);
    }

    public void disableCube()
    {
        isAttacking = false;
        AttackCube.SetActive(false);
    }
   
}

