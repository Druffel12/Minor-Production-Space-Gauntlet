using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    float moveVertical;
    float moveHorizontal;
    float speed;
    Vector3 movement;

    bool canMove;

    Rigidbody rb;
    
    public PlayerStatsObj stats;

    private void Start()
    {

        speed = stats.speed;
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }


    void Move()
    {
        //rotates the player
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(movement.normalized),
                                                  9 * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(movement.normalized);
            //Vector3 desiredLook = transform.position + movement;
            //transform.LookAt(desiredLook);
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
    
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        if(state.Triggers.Left >= 0.4)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        Move();
	}
}