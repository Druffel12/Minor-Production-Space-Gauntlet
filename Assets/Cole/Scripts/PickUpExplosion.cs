using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplosion : MonoBehaviour {
    public float Damage;
    public GameObject ExplosionR;
    Animator anim;

    private void Awake()
    {
        ExplosionR.SetActive(false);
    }

    public void EnableExplosionR()
    {
        ExplosionR.SetActive(true);
    }

    public void SExplosionDamage(Vector3 location, float radius, float damage)
    {
        Collider[] EnemysInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in EnemysInRange)
        {
            
        }
        
    }

    public void TExplosionDamage()
    {
        anim.SetTrigger("UseGrenade");
    }
}
