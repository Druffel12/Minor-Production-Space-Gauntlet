using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeManager : MonoBehaviour
{
    public List<Image> grenades;
	
    public void GrenadeRunThrough(PlayerController player)
    {
        for (int i = 0; i < player.grenadeCount; i++)
        {
            grenades[i].gameObject.SetActive(true);
        }
    }

    public void GrenadeUsed(PlayerController player)
    {
        grenades[player.grenadeCount].gameObject.SetActive(false);
    }

}
