using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GunScript : MonoBehaviour
{
    float range;
    float timeBetweenShots;
    float damage;

    public LayerMask mask;

    Animator anim;
   
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public AudioSource gunShot;

    public LineRenderer line;

    public GunEffects effects;

    public PlayerStatsObj stats;

    AudioSource missedSound;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        playerIndex = GetComponentInParent<PlayerController>().playerIndex;

        missedSound = GetComponent<AudioSource>();

        range = stats.range;
        damage = stats.damage;
    }

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        timeBetweenShots += Time.deltaTime;
        // checks if the Triggers or the X button is pressed

        if(state.Triggers.Right >= 0.4 || state.Buttons.X == ButtonState.Pressed)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
        //if(GetComponentInParent<PlayerController>().canMove == true)
        //{
        //    line.enabled = true;
        //}
        //else
        //{
        //    line.enabled = false;
        //}

        if (state.Triggers.Right >= 0.4 && timeBetweenShots >= stats.timeBetweenShots ||
            state.Buttons.X == ButtonState.Pressed && timeBetweenShots >= stats.timeBetweenShots)
        {
            timeBetweenShots = 0;
            Shoot(transform.position,transform.forward,range);
            anim.SetTrigger("isFiring");
            line.enabled = true;
            effects.ActivateEffects();
        }
        else
        {
            line.enabled = false;
            //effects.DisableEffects();
        }
       
    }

    void Shoot(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit hit;
        Vector3 endPosition = targetPosition + (length * direction);

        
        if(Physics.Raycast(ray, out hit, range, mask.value))
        {
            endPosition = hit.point;

            //checks if the raycast hits an enemy
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            {
                //calls the damage function
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();

                AIHP enemyHP = hit.transform.GetComponent<AIHP>();

                ScoreCounter score = GetComponentInParent<ScoreCounter>();

                if (damageable != null)
                {
                    damageable.Damage(damage);
                    if (enemyHP != null)
                    {
                        if (enemyHP.EnemyHP == enemyHP.MaxHP)
                        {
                            score.ScoreIncrease(20);
                        }
                    }
                }                
            }
            else
            {
                missedSound.Play();
            }
        }
        effects.StartDisable(stats.timeBetweenShots * 0.5f);
        
        //draws the line on the raycast
        line.SetPosition(0, effects.transform.position);
        line.SetPosition(1, endPosition);

        //plays gunshot sound 
        if(gunShot.isPlaying == false)
        {
            gunShot.Play();
        }
        
    }
}
