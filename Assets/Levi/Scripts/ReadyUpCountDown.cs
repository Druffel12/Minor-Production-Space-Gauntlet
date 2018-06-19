using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyUpCountDown : MonoBehaviour
{
    public Image startButton;
    public Image backButton;
    public Text timerText;
    public string level;
    float counter;
    public bool pressedStart;
    PlayerSelectManager playerManager;

    public void StartCountdown()
    {
        counter = 5;
        timerText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        pressedStart = true;
    }

    public void StopCountDown()
    {
        timerText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);

        pressedStart = false;
    }

    public void setStartButton()
    {
        if (playerManager.p4Ready == true)
        {
            if (playerManager.p3Ready == true)
            {
                if (playerManager.p2Ready == true)
                {
                    if (playerManager.p1Ready == true)
                    {
                        startButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        startButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    startButton.gameObject.SetActive(false);
                }
            }
            else
            {
                startButton.gameObject.SetActive(false);
            }

        }
        else
        {
            if (playerManager.p3Ready == true)
            {
                if (playerManager.p2Ready == true)
                {
                    if (playerManager.p1Ready == true)
                    {
                        startButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        startButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    startButton.gameObject.SetActive(false);
                }
            }
            else
            {
                if (playerManager.p2Ready == true)
                {
                    if (playerManager.p1Ready == true)
                    {
                        startButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        startButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (playerManager.p1Ready == true)
                    {
                        startButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        startButton.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    void Start()
    {
        pressedStart = false;
        playerManager = FindObjectOfType<PlayerSelectManager>();
    }


    void Update()
    {
        if (pressedStart == true)
        {
            counter -= Time.deltaTime;

            float seconds = Mathf.RoundToInt(counter);

            timerText.text = seconds.ToString();

            if (counter <= 0)
            {
                SceneManager.LoadScene(level);
            }
        }

    }
}
