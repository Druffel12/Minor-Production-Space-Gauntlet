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
    Animator anim;
    CameraController cameraController;
    
    //damage function for harming creatures
    public void Damage(float Amt)
    {
        health -= Amt;
        //anim.SetTrigger("isDamaged");
        updateHealth(health);
        //Debug.Log("This was the default health version of Idamageable");
        if (health <= 0)
        {
            //anim.SetBool("isDead", true);
            Death();
        }
    }

    public void Death()
    {
        //T need to add animation also possible UI element 
        
        //PlayerNumManager.instance.RemovePlayer(gameObject);
        Destroy(gameObject);
    }

    string updateHealth(float value)
    {
        return "O2: " + value.ToString();
    }
	// Use this for initialization
    //attempts damage to hit object by looking for idamageable 
	void Start ()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        anim = GetComponent<Animator>();

        health = stats.maxHealth;
        healthText.text = "O2: " + health.ToString();
        StartCoroutine("HealthTick");
    }

    IEnumerator HealthTick()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1);
            healthText.text = "O2: " + health.ToString();
            Damage(1);
        }
    }

}

