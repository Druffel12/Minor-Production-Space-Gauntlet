using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    GamePadState state;
    GamePadState prevState;

    public Sprite deactivated;
    public Sprite activated;

    Image characterImage;

    public Image startButton;

    PlayerSelectManager playerManager;

    public PlayerIndex pIndex;
    public bool isReady;

	void Start ()
    {
        isReady = false;
        characterImage = GetComponent<Image>();
        playerManager = FindObjectOfType<PlayerSelectManager>();
	}
	

    void WaitForInput()
    {
        //isReady to true or false
        if(isReady == true)
        {
            isReady = false;
            characterImage.sprite = deactivated;
        }
        else
        {
            isReady = true;
            characterImage.sprite = activated;
        }

        //Call update playerSelect
        playerManager.updatePlayerSelectManager(pIndex, isReady);
       
    }

    void setStartButton()
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


    void Update()
    {
        prevState = state;
        state = GamePad.GetState(pIndex);

        //Check to see if player at pIndex has hit -Confirm button-
        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
            WaitForInput();
            setStartButton();
        }

        if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed && startButton.gameObject.activeInHierarchy == true)
        {
            SceneManager.LoadScene("Scene 1");
        }
    }
}
