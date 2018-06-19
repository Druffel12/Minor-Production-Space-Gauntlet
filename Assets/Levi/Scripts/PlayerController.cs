using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public PlayerIndex playerIndex;
    GrenadeManager grenadeManager;

    public GameObject gun;
    public GameObject forward;
    public GameObject Grenade;

    public LayerMask mask;

    GamePadState state;
    GamePadState prevState;

    float moveVertical;
    float moveHorizontal;
    float speed;
    Vector3 movement;

    public int grenadeCount;

    public bool canMove;

    Rigidbody rb;

    LineRenderer laserSight;
    Ray ray;

    Animator anim;

    public PlayerStatsObj stats;

    private void Start()
    {
        anim = GetComponent<Animator>();
        speed = stats.speed;
        rb = GetComponent<Rigidbody>();
        canMove = true;
        laserSight = GetComponent<LineRenderer>();
        grenadeManager = GetComponent<GrenadeManager>();
    }


    public void SetCrouchState()
    {
        Debug.Log("I am crouched");

    }

    void Move()
    {
        //rotates the player
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(movement.normalized),
                                                  9 * Time.deltaTime);
        }
     
      //logs the analog sticks movement in a float
        moveHorizontal = state.ThumbSticks.Left.X;
        moveVertical = state.ThumbSticks.Left.Y;
        

        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        Vector3 desiredVelocity = movement.normalized * speed;
        
        //moves the player
        if(canMove == true)
        {
            rb.AddForce(desiredVelocity - rb.velocity, ForceMode.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void LaserSightActivator()
    {
        ray = new Ray(forward.transform.position, forward.transform.forward);
        RaycastHit hit;
        Vector3 endPosition = gun.transform.position + (stats.range * forward.transform.forward);

        if(Physics.Raycast(ray, out hit, stats.range, mask.value))
        {
            endPosition = hit.point;
        }

        laserSight.SetPosition(0, gun.transform.position);
        laserSight.SetPosition(1, endPosition);
        laserSight.enabled = true;

    }

	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        if(state.Triggers.Left >= 0.4)
        {
            canMove = false;
            LaserSightActivator();
            anim.SetBool("isCrouched", true);
        }
        else
        {
            canMove = true;
            laserSight.enabled = false;
            anim.SetBool("isCrouched", false);    
        }
        
        if(prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            if(grenadeCount > 0)
            {
                
                anim.SetTrigger("isGrenade");
                grenadeCount--;
                grenadeManager.GrenadeUsed(this);
                
                Instantiate(Grenade, transform.position + transform.forward * 2, transform.rotation);
            }
        }

        Move();
        float runValue = Mathf.Clamp(Mathf.Abs(rb.velocity.magnitude), 0, 1);
        anim.SetFloat("isRunning", rb.velocity.magnitude);
	}
}