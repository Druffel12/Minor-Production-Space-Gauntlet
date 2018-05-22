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

    public LineRenderer line;

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);

        // checks if the Triggers are pressed
        if (prevState.Triggers.Right <= 0.4 && state.Triggers.Right >= 0.4 )
        {
            Shoot(transform.position,transform.forward,range);
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }

    void Shoot(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit hit;
        Vector3 endPosition = targetPosition + (length * direction);

        if(Physics.Raycast(ray, out hit, range))
        {
            endPosition = hit.point;

            //checks if the raycast hits an enemy
            if(hit.transform.tag == "Enemy")
            {
                //calls the damage function
                hit.transform.GetComponent<IDamageable>().Damage(damage);
            }
        }

        
        //draws the line on the raycast
        line.SetPosition(0, targetPosition);
        line.SetPosition(1, endPosition);
    }
}
