using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GunScript : MonoBehaviour
{
    float range;
    float timeBetweenShots;
    float damage;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public LineRenderer line;
    public PlayerStatsObj stats;

    private void Start()
    {
        playerIndex = GetComponentInParent<PlayerController>().playerIndex;
        range = stats.range;
        damage = stats.damage;
    }

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        timeBetweenShots += Time.deltaTime;
        // checks if the Triggers or the X button is pressed
        if (state.Triggers.Right >= 0.4 && timeBetweenShots >= stats.timeBetweenShots ||
            state.Buttons.X == ButtonState.Pressed && timeBetweenShots >= stats.timeBetweenShots)
        {
            timeBetweenShots = 0;
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
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            {
                //calls the damage function
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.Damage(damage);
                }
            }
        }

        
        //draws the line on the raycast
        line.SetPosition(0, targetPosition);
        line.SetPosition(1, endPosition);
    }
}
