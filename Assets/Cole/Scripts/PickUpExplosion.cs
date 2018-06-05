using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplosion : MonoBehaviour
{
    public float Damage;
    public float explosionRadius;
    public LayerMask mask;
    public bool Test;
    public float Delay;
    public GameObject EffectsCube;
    private bool HasExploded;


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
        if (HasExploded == false)
        {
            Debug.Log("BOOOM");
            //T needs some kind of sound effect for explosion
            Collider[] EnemysInRange = Physics.OverlapSphere
                (location, explosionRadius, mask.value);
            HasExploded = true;
            GameObject Effects = Instantiate(EffectsCube);
            Effects.transform.position = transform.position;
            foreach (Collider col in EnemysInRange)
            {
                IDamageable dummy = col.GetComponent<IDamageable>();
                if (dummy != null)
                {
                    dummy.Damage(Damage);
                    
                }
            }
            Destroy(gameObject);
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

    //shot explosive 
    public void SExplosionDamage()
    {
        EnableExplosion(transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}
  
