using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour, IDamageable
{
    public float health;
    //public float maxHP;
    //public GameObject test;
    public Text healthText;
    public PlayerStatsObj stats;

    //damage function for harming creatures
    public void Damage(float Amt)
    {
        health -= Amt;
        //Debug.Log("This was the default health version of Idamageable");
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


	// Use this for initialization
    //attempts damage to hit object by looking for idamageable 
	void Start ()
    {
        health = stats.maxHealth;
        //maxHP = health;
        //IDamageable Attempt = test.GetComponent<IDamageable>();
        //if (Attempt != null)
        //{
        //    //T setup damage to hit creature
        //    //Attempt.Damage();
        //}
        StartCoroutine("HealthTick");
    }

    IEnumerator HealthTick()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            healthText.text = health.ToString();
            health--;
        }
    }

}

