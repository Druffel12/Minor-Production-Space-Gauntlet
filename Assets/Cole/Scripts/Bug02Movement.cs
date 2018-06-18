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
    public float LowRange;
    public float HighRange;

    //bools
    public bool isAttacking;
    private bool CanWander = true;

    //misc 
    NavMeshAgent agent;
    Vector3 Dir;
    Animator  Anim;

    private void Awake()
    {
        MyTransform = transform;
    }
    // Use this for initialization
    void Start ()
    {
        Target = null;
        agent = GetComponent<NavMeshAgent>();
        Anim.GetComponent<Animator>();
		//agent 
	}

    // Update is called once per frame
    void Update ()
    {

       // LookAtPlayer();

        Player = FindNearestPlayer();

		if (Player != null)
        {
            if (Player.gameObject.activeInHierarchy)
            {
                agent.destination = Player.position;

                Debug.DrawLine(transform.position, Player.transform.position);
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
          if (agent.velocity.magnitude > 0)
        {
            transform.LookAt(transform.position + agent.velocity);
        }
    }
}
