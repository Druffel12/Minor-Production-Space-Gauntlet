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
    public AudioSource explosionSound;

    public void Start()
    {
        explosionSound = Camera.main.GetComponentInChildren<AudioSource>();
    }

    public void Update()
    {
        if (Test == true)
        {
            EnableExplosion(transform.position);
            Test = false;
        }
    }

    public void EnableExplosion(Vector3 location)
    {
        if (HasExploded == false)
        {
            //Debug.Log("BOOOM");
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
            //explosionSound.Play();
            Destroy(Effects,Delay + 3);
            Destroy(gameObject);
        }
    }

    IEnumerator DelayExplode()
    {
        yield return new WaitForSeconds(Delay);
        EnableExplosion(transform.position);
    }

    public void ExplodeWithDelay()
    {
        StartCoroutine(DelayExplode());
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
  
