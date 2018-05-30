using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PickUpScript : MonoBehaviour
{
    float healthIncrease;
    int score;
    public PickUpStatsObj stats;
    public ObjectPooler pool;

    private void Start()
    {
        healthIncrease = stats.healthIncrease;
        score = stats.scoreIncrease;
        pool = GetComponent<ObjectPooler>();
    }

    void ReturnToPool()
    {
        pool.PooledObjects.Add(gameObject);
        gameObject.SetActive(false);
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
                    if (pool != null)
                    {
                        playerScore.ScoreIncrease(score);
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
