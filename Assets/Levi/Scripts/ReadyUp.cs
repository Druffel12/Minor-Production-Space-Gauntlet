using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    public Text timerText;

    public Canvas mainMenu;
    public Canvas playerSelect;

    GamePadState state;
    GamePadState prevState;

    public Sprite deactivated;
    public Sprite activated;

    Image characterImage;

    public Image startButton;
    public Image backButton;
    PlayerSelectManager playerManager;

    public PlayerIndex pIndex;
    public bool isReady;

	void Start ()
    {
        isReady = false;
        characterImage = GetComponent<Image>();
        playerManager = FindObjectOfType<PlayerSelectManager>();
	}

    

    private void OnEnable()
    {
        counter = .1f;
        canPress = false;
        isReady = false;
        characterImage = GetComponent<Image>();
        playerManager = FindObjectOfType<PlayerSelectManager>();
        characterImage.sprite = deactivated;
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

    bool pressedStart = false;
    float counter;


    void StartCountdown()
    {
        counter = 5;
        timerText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        pressedStart = true;
        
    }

    void StopCountDown()
    {
        timerText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);

        pressedStart = false;
    }

    bool canPress;

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(pIndex);
        if (canPress == false)
        {
            counter -= Time.deltaTime;
        }

        if(counter <= 0)
        {
            canPress = true;
        }

        //Check to see if player at pIndex has hit -Confirm button-
        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && canPress == true)
        {
            WaitForInput();
            setStartButton();
        }


        if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && pressedStart == false)
        {
            mainMenu.gameObject.SetActive(true);
            playerSelect.gameObject.SetActive(false);
        }



        if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed && startButton.gameObject.activeInHierarchy == true)
        {
            StartCountdown();          
        }

        if (pressedStart == true)
        {
            counter -= Time.deltaTime;

            float seconds = Mathf.RoundToInt(counter);

            timerText.text = seconds.ToString();

            if(counter <= 0)
            {
                SceneManager.LoadScene("Scene 1");
            }

            if(prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed ||
               prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
            {
                StopCountDown();
            }
        }
    }
}
