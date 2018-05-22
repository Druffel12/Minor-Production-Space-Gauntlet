using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour, IDamageable
{
    public float health;
    public GameObject test;

    //damage function for harming creatures
    public void Damage(float Amt)
    {
        health -= Amt;
        Debug.Log("This was the default health version of Idamageable");
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //T need to add animation also possible UI element 
        Destroy(gameObject);
    }
}

