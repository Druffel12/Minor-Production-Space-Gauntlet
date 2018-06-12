﻿using System.Collections;
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
    
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        ray = new Ray(forward.transform.position, forward.transform.forward);

        if(state.Triggers.Left >= 0.4)
        {
            canMove = false;
            laserSight.enabled = true;
            laserSight.SetPosition(0, gun.transform.position);
            laserSight.SetPosition(1, gun.transform.position + forward.transform.forward * stats.range);
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
                grenadeCount--;
                grenadeManager.GrenadeUsed(this);
                Instantiate(gameObject);
            }
        }

        Move();
        float runValue = Mathf.Clamp(Mathf.Abs(rb.velocity.magnitude), 0, 1);
        anim.SetFloat("isRunning", rb.velocity.magnitude);
	}
}