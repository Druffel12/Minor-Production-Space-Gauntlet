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
        //T need to add animation 
        Destroy(gameObject);
    }

	// Use this for initialization
    //attempts damage to hit object by looking for idamageable 
	void Start ()
    {
        IDamageable Attempt = test.GetComponent<IDamageable>();
        if (Attempt != null)
        {
            //T setup damage to hit creature
            //Attempt.Damage();
        }
    }
}

// system for damaging and destroying gameobjects
class OtherHp: MonoBehaviour , IDamageable
{
    float health;
    public void Damage(float Amt)
    {
        health += Amt;
        if (health >+ 50)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
