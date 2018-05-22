using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public float healthIncrease;

    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HP playerHP = other.GetComponent<HP>();

            if(playerHP != null)
            {
                playerHP.health += healthIncrease;
                //if (playerHP.health >= playerHP.maxHP)
                //{
                //    playerHP.health = playerHP.maxHP;
                //}
                Destroy(gameObject);
            }
        }
    }
}
