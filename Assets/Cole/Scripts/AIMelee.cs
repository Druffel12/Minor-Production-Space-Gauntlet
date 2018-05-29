using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMelee : MonoBehaviour {


    public float cubeLifetime;
    //public AIMovement ourAI;
    public float Damage;
    //void OnEnable()
    //{
    //    StartCoroutine(turnOffCube());
    //}

    //IEnumerator turnOffCube()
    //{
    //    yield return new WaitForSeconds(cubeLifetime);
    //    ourAI.isAttacking = false;
    //    gameObject.SetActive(false);
    //    Debug.Log("Attack Cube off");
    //}

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<IDamageable>().Damage(Damage);
        }
        //Damage
        //If Damage Succesful
        //ourAI.isAttacking = false;
        //gameObject.SetActive(false);
    }

    
}
