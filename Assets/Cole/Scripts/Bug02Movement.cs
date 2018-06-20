using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bug02Movement : MonoBehaviour {

    //Transforms
    private Transform Player;
    private Transform MyTransform;
    private Transform Target;
    

    //floats
    public float Range;
    public float SearchRange;
    public float WanderRadius;
    public float WanderTimer;
    private float Timer;
    private float AttackTimer;
    public float AttackDelay;
    public float LowRange;
    public float HighRange;
    public float SpikeSpeed;
    public float ShotDelay;

    //bools
    public bool isAttacking;
    private bool CanWander = true;

    //misc 
    NavMeshAgent agent;
    Vector3 Dir;
    Animator  Anim;
    public GameObject Spike;

    private void Awake()
    {
        MyTransform = transform;
    }
    // Use this for initialization
    void Start ()
    {
        //Target = null;
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        //Anim.GetComponent<Animator>();
		//agent 
	}

    // Update is called once per frame
    void Update ()
    {
        AttackTimer -= Time.deltaTime;
        // LookAtPlayer();

        Player = FindNearestPlayer();
       
        if (Player != null)
        {
            if (Player.gameObject.activeInHierarchy)
            {
                
                if (Vector3.Distance(transform.position, Player.position) < Range - 2)
                {
                    Vector3 dir = (transform.position + Player.position).normalized;

                    agent.destination = transform.position + dir * 5;

                    Debug.DrawLine(transform.position, Player.transform.position);
                }
                else if (Vector3.Distance(transform.position, Player.position) < Range)
                {
                    LookAtPlayer();
                    if (AttackTimer <= 0.0f)
                    {
                        Attack();
                        AttackTimer = AttackDelay;
                    }
                   
                }
            }
            else
            {
                Player = null;
            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SearchRange);
    }

    Transform FindNearestPlayer()
    {
        Transform retval = null;
        Collider[] Neighbors = Physics.OverlapSphere(transform.position, SearchRange, 1 << 9);
        float min = Mathf.Infinity;
        foreach(Collider guy in Neighbors)
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

    private void shoot()
    {
        if (Vector3.Distance(transform.position, Player.position) < Range + agent.stoppingDistance && !isAttacking)
        {
            Anim.SetTrigger("isAttacking");
            isAttacking = true;
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

    void LookAtPlayer()
    {    
      transform.LookAt(Player.transform.position);  
    }

    void Attack()
    {
        if (Player == true)
        {
                                
            GameObject spawnbaby = Instantiate(Spike);
            spawnbaby.transform.position = transform.position + transform.forward * 2 + Vector3.up * 2;
            Vector3 ShootDir = Player.transform.position - spawnbaby.transform.position;
            spawnbaby.transform.LookAt(Player.transform); //spawnbaby.transform.position + ShootDir.normalized;
            spawnbaby.GetComponent<Rigidbody>().velocity = ShootDir.normalized * SpikeSpeed;
            LookAtPlayer();
            Debug.Log("Death to the infidels");
        }
    }
}
