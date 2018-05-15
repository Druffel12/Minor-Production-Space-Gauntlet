using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    public float speed;

    PlayerIndex playerIndex;
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

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        Move();
	}
}