using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PickUpScript : MonoBehaviour
{
    float healthIncrease;
    int score1;
    int score2;
    int score3;
    public PickUpStatsObj stats;
    public ObjectPooler pool;

    private void Start()
    {
        healthIncrease = stats.healthIncrease;
        score1 = stats.scoreIncrease1;
        score2 = stats.scoreIncrease2;
        score3 = stats.scoreIncrease3;
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
                        playerScore.ScoreIncrease(score1);
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score1);
                        Destroy(gameObject);
                    }
                }
            }

            if (gameObject.tag == "Treasure2")
            {
                ScoreCounter playerScore = other.GetComponent<ScoreCounter>();
                if (playerScore != null)
                {
                    if (pool != null)
                    {
                        playerScore.ScoreIncrease(score2);
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score2);
                        Destroy(gameObject);
                    }
                }
            }

            if (gameObject.tag == "Treasure3")
            {
                ScoreCounter playerScore = other.GetComponent<ScoreCounter>();
                if (playerScore != null)
                {
                    if (pool != null)
                    {
                        playerScore.ScoreIncrease(score3);
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score3);
                        Destroy(gameObject);
                    }
                }
            }

            if (gameObject.tag == "Grenade")
            {
                PlayerController player = other.GetComponent<PlayerController>();
                GrenadeManager grenade = other.GetComponent<GrenadeManager>();
                if (player.grenadeCount < 3)
                {
                    player.grenadeCount++;
                    if(pool != null)
                    {
                        grenade.GrenadeRunThrough(player);
                        ReturnToPool();
                    }
                    else
                    {
                        grenade.GrenadeRunThrough(player);
                        Destroy(gameObject);
                    }
                }
                
            }
        }
    }
}
