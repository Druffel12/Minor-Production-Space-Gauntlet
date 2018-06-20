using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    Transform door;
    PlayerController player;

    void OpenDoor()
    {
        door = GetComponentInParent<Transform>();
        Debug.Log("OPEN");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if(player.hasKey == true)
                {
                    OpenDoor();
                }
            }
        }

    }
}
