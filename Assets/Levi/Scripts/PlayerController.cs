using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canMoveUp;
    public bool canMoveDown;


    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    float moveVertical;
    float moveHorizontal;
    Vector3 movement;


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


        if(canMoveLeft == false)
        {
            if(moveHorizontal > 0)
            {
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }
        }
        else if (canMoveRight == false)
        {
            if (moveHorizontal < 0)
            {
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }
        }
        else if (canMoveUp == false)
        {
            if(moveVertical < 0)
            {
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }
        }
        else if (canMoveDown == false)
        {
            if (moveVertical > 0)
            {
                transform.Translate(movement * speed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        //Debug.Log("X = " + state.ThumbSticks.Left.X.ToString());
        //Debug.Log("Y = " + state.ThumbSticks.Left.Y.ToString());
    }
    
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        Move();
	}
}