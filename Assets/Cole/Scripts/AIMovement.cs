using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    //Transforms
    private Transform Player;
    private Transform MyTransform;
    private Transform Target;

    //GameObjects
    public GameObject AttackCube;

    //Floats
    public float Range;
    public float searchRange;
    public float thoughtDelay;
    float thoughtTimer;
    public float WanderRadius;
    public float WanderTimer;
    private float Timer;

    //Bools
    public bool isAttacking;
    public bool isRunning;
    private bool CanWander = true;

    //Misc
    Animator anim;
    NavMeshAgent agent;
    Vector3 Dir;

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
        agent.updateRotation = false;
        if (CanWander == true)
        {
            Vector3 NewPos = RandomNavMesh(transform.position, WanderRadius, -1);
            Timer = 0;
        }
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
            CanWander = false;
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

        Wander();
        if(agent.velocity.magnitude > 0)
        {
            transform.LookAt(transform.position + agent.velocity);
        }


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
        //if (Vector3.Distance(transform.position, Player.position) <= Range)
        //{
        //    transform.position += Vector3.back;
        //}
        if(Vector3.Distance(transform.position, Player.position) < Range + agent.stoppingDistance  && !isAttacking)
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
   
    private void Wander()
    {
        Timer += Time.deltaTime;
        float dist = Vector3.Distance(Target.position, transform.position);

        if(Timer >= WanderTimer)
        {
            agent.speed = 10;
            Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
            agent.destination = newPos;
            Timer = 0;
        }
    }

    public Vector3 RandomNavMesh(Vector3 origin, float dist, int LayerMask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;
        randDirection.y = transform.position.y;
        NavMeshHit NavHit;

        NavMesh.SamplePosition(randDirection, out NavHit, dist, LayerMask);

        return NavHit.position;
    }
}

