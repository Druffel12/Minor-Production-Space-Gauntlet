using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableGrenade : MonoBehaviour {

    public Rigidbody rb;
    PickUpExplosion explosion;
    public float strength;
    

	// Use this for initialization
	void Start ()
    {
        explosion = GetComponent<PickUpExplosion>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * strength, ForceMode.Impulse);
        explosion.ExplodeWithDelay();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable dummy = collision.collider.GetComponent<IDamageable>();
        if(dummy != null)
        {
            explosion.EnableExplosion(transform.position);
           
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable dummy = other.GetComponent<IDamageable>();
        if(dummy != null)
        {
            explosion.EnableExplosion(transform.position);
           
        }
    }
}
