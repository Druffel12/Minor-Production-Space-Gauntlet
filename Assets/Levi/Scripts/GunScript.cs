using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GunScript : MonoBehaviour
{
    public float range;
    public float damage;

    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
        }
    }
}
