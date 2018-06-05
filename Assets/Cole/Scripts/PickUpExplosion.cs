using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplosion : MonoBehaviour {
    public float Damage;
    public float explosionRadius;
    public LayerMask mask;
    public bool Test;
    public float Delay;


    public void Update()
    {
        if (Test == true)
        {
            EnableExplosion(transform.position);
            Test = false;
        }
    }

    //private void Start()
    //{
    //    explodeWithDelay();
    //}

    public void EnableExplosion(Vector3 location)
    {
        Debug.Log("BOOOM");
        //T needs some kind of sound effect for explosion
        Collider[] EnemysInRange = Physics.OverlapSphere
            (location, explosionRadius, mask.value);
        foreach (Collider col in EnemysInRange)
        {
            IDamageable dummy = col.GetComponent<IDamageable>();
            if (dummy != null)
            {
                dummy.Damage(Damage);
            }
        }
       
    }

    IEnumerator delayExplode()
    {
        yield return new WaitForSeconds(Delay);
        EnableExplosion(transform.position);
    }

    public void explodeWithDelay()
    {
        StartCoroutine(delayExplode());
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    IDamageable dummy = other.collider.GetComponent<IDamageable>();
    //    if(dummy != null)
    //    {
    //        EnableExplosion(transform.position);
    //    }
    //}



    //shot explosive 
    public void SExplosionDamage()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    //thrown explosion
    //public void TExplosionDamage()
    //{
    //    

    //    if()
    //}
}
