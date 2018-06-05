using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHP : MonoBehaviour, IDamageable {

    public float health;
    public bool IsDead;

    //Damage to pickupHP
    public void Damage(float Amnt)
    {
        health -= Amnt;
        Debug.Log("This was the pickups version of Idamageable");
        if(health <= 0 && IsDead == false)
        {
           
            IsDead = true;
            Death();
        }
    }

    // runs death for said HP pick up 
    public void Death()
    {
        //T add sound clip for shooting HP pick up
        GetComponent<PickUpExplosion>().EnableExplosion(transform.position);
        Destroy(gameObject);

    }
   
}
