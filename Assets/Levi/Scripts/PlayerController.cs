using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    float moveVertical;
    float moveHorizontal;
    Vector3 movement;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Move()
    {
      if(moveHorizontal!= 0|| moveVertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(movement),
                                                  9 * Time.deltaTime);
        }

        moveHorizontal = state.ThumbSticks.Left.X;
        moveVertical = state.ThumbSticks.Left.Y;

        movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.MovePosition(rb.position + movement * 0.5f);

        //transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        Move();
	}
}