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
    public AudioClip soundEffect;
    public GameObject PlayAudio;
    private void Start()
    {
        //soundEffect = GetComponent<AudioSource>();
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


    void PLAYSOUND()
    {
        GameObject spawnedAudio = Instantiate(PlayAudio);
        AudioSource s = spawnedAudio.GetComponent<AudioSource>();
        s.clip = soundEffect;
        s.Play();
        Destroy(s, 5);
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
                    PLAYSOUND();
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
                        PLAYSOUND();
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score1);
                        PLAYSOUND();
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
                        PLAYSOUND();
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score2);
                        PLAYSOUND();
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
                        PLAYSOUND();
                        ReturnToPool();
                    }
                    else
                    {
                        playerScore.ScoreIncrease(score3);
                        PLAYSOUND();
                        Destroy(gameObject);
                    }
                }
            }

            if (gameObject.tag == "Grenade")
            {
                PlayerController player = other.GetComponent<PlayerController>();
                GrenadeManager grenade = other.GetComponent<GrenadeManager>();
                if (player != null)
                {
                    if (player.grenadeCount < 3)
                    {
                        player.grenadeCount++;
                        if (pool != null)
                        {
                            grenade.GrenadeRunThrough(player);
                            PLAYSOUND();
                            ReturnToPool();
                        }
                        else
                        {
                            grenade.GrenadeRunThrough(player);
                            PLAYSOUND();
                            Destroy(gameObject);
                        }
                    }
                }               
            }
        }
    }
}
