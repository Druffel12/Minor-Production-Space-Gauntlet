using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplosion : MonoBehaviour {
    public float Damage;

    public void ExplosionDamage(Vector3 Center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(Center, radius);

    }

}
