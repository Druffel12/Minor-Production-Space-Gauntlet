﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableGrenade : MonoBehaviour {


    PickUpExplosion explosion;
	// Use this for initialization
	void Start () {
        explosion = GetComponent<PickUpExplosion>();
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
