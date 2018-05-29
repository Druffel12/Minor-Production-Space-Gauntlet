using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PickUpScript : MonoBehaviour
{
    float healthIncrease;
    int score;
    public PickUpStatsObj stats;

    private void Start()
    {
        healthIncrease = stats.healthIncrease;
        score = stats.scoreIncrease;
    }

    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (gameObject.tag == "HealthPickUp")
            {
                HP playerHP = other.GetComponent<HP>();

                if (playerHP != null)
                {
                    playerHP.health += healthIncrease;
                    playerHP.healthText.text = playerHP.health.ToString();
                    Destroy(gameObject);
                }
            }

            if(gameObject.tag == "Treasure")
            {
                ScoreCounter playerScore = other.GetComponent<ScoreCounter>();
                if (playerScore != null)
                {
                    playerScore.ScoreIncrease(score);
                    Destroy(gameObject);
                }
            }
        }
    }
}
