using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShot : MonoBehaviour {

    public float SpikeDamage;

    private void OnTriggerEnter(Collider other)
    {
        HP Temp = other.GetComponent<HP>();
        if(Temp != null)
        {
            Temp.Damage(SpikeDamage);
        }
   
    }
}
