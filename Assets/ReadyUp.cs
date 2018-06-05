using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class ReadyUp : MonoBehaviour
{
    GamePadState state;
    GamePadState prevState;

    PlayerSelectManager playerManager;

    public PlayerIndex pIndex;
    public bool isReady;

	void Start ()
    {
        isReady = false;
        playerManager = FindObjectOfType<PlayerSelectManager>();
	}
	

    void WaitForInput()
    {
        //isReady to true or false
        if(isReady == true)
        {
            isReady = false;
        }
        else
        {
            isReady = true;
        }

        //Call update playerSelect
        playerManager.updatePlayerSelectManager(pIndex, isReady);
       
    }




	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(pIndex);

        //Check to see if player at pIndex has hit -Confirm button-
        if(prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
            WaitForInput();
        }
	}
}
