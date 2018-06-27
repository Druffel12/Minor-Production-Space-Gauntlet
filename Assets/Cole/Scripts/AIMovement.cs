using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    //Transforms
    public Transform Player;
    private Transform MyTransform;
    private Transform Target;
    private Transform LastSpot;

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
    public float LowRange;
    public float HighRange;

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
        WanderTimer = 0;
    }

    private void Start()
    {
        Timer = Random.Range(LowRange, HighRange);
        agent = GetComponent<NavMeshAgent>();
        Target = null;
        anim = GetComponent<Animator>();
        agent.updateRotation = false;
        if (CanWander == true)
        {
            Vector3 NewPos = RandomNavMesh(transform.position, WanderRadius, -1);
           
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRange);
    }

    //trigger zone for finding player tags
    public Transform findNearestPlayer()
    {
        Transform retval = null;
        Collider[] neighbors = Physics.OverlapSphere(transform.position, searchRange, 1 << 9);
        float min = Mathf.Infinity;
        foreach(Collider guy in neighbors)
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
    public Transform findNearestPlayer(float alertBonus)
    {
        Transform retval = null;
        Collider[] neighbors = Physics.OverlapSphere(transform.position, searchRange + alertBonus, 1 << 9);
        float min = Mathf.Infinity;
        foreach (Collider guy in neighbors)
        {

            CanWander = false;
            float distance = Vector3.Distance(transform.position, guy.transform.position);
            if (distance <= min)
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

        if (Player == null)
        {
            Wander();
        }

        else
        {
            if (Vector3.Distance(transform.position, Player.position) < Range + agent.stoppingDistance && !isAttacking)
            {
                transform.LookAt(Player);
            }

            else if (agent.velocity.magnitude > 0)
            {
                transform.LookAt(transform.position + agent.velocity);
            }

            else
            {
                transform.LookAt(Player);
            }
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
              
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);

               
                Attack();
                
            }

            else
            {
                Player = null;
                agent.isStopped = true;
                anim.SetBool("isRunning", false);
                anim.SetTrigger("isIdle");
                
            }
           
            Target = null;
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

    //enables attack cube function
    public void enableCube()
    {
        AttackCube.SetActive(true);
    }

    //disables attack cube
    public void disableCube()
    {
        isAttacking = false;
        AttackCube.SetActive(false);
    }

    //wander script
    Vector3 debugPos;
    private void Wander()
    {
        Timer += Time.deltaTime;
        Debug.DrawLine(transform.position, debugPos);

        if (agent.velocity.magnitude > 0)
        {
            transform.LookAt(transform.position + agent.velocity);
        }


        if (Timer >= WanderTimer)
        {
            anim.SetBool("isWalking", true);
            agent.speed = 10;
            Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
            debugPos = newPos;
            agent.destination = newPos;
            Timer = 0;
            WanderTimer = Random.Range(LowRange, HighRange);
            anim.SetBool("isRunning", false);
        }
        

        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance)
        {
            anim.SetBool("isWalking", false);
        }
    }

    //random nav mesh for wander
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

