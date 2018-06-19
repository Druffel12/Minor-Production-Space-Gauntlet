using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    public GameObject joinText;

    public Canvas mainMenu;
    public Canvas playerSelect;

    GamePadState state;
    GamePadState prevState;

    public Sprite deactivated;
    public Sprite activated;

    public Animator cameraAnim;
    public Animator lightsAnim;

    Image characterImage;

    PlayerSelectManager playerManager;

    public PlayerIndex pIndex;
    public bool isReady;

    public ReadyUpCountDown ready;

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

    private void OnDisable()
    {
        if (lightsAnim != null)
        {
            lightsAnim.SetBool("LightsOn", false);
            ready.startButton.gameObject.SetActive(false);
        }
    }

    void WaitForInput()
    {
        //isReady to true or false
        if(isReady == true)
        {
            isReady = false;
            joinText.SetActive(true);
            lightsAnim.SetBool("LightsOn", false);
        }
        else
        {
            isReady = true;
            joinText.SetActive(false);
            Flicker();
            lightsAnim.SetBool("LightsOn", true);
        }

        //Call update playerSelect
        playerManager.updatePlayerSelectManager(pIndex, isReady);
       
    }


    float counter;


    void Flicker()
    {
        lightsAnim.SetTrigger("UnFlicker");
        lightsAnim.SetTrigger("Flicker");
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
            ready.setStartButton();
        }

        if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && ready.pressedStart == false)
        {
            cameraAnim.SetTrigger("MainMenu");
            mainMenu.gameObject.SetActive(true);
            playerSelect.gameObject.SetActive(false);
        }

        if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed && ready.startButton.gameObject.activeInHierarchy == true)
        {
            ready.StartCountdown();
        }

        if (ready.pressedStart == true)
        {
            if(prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed ||
               prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
            {
                ready.StopCountDown();
            }
        }
    }
}
