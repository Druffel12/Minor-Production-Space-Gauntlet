using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class ButtonManager : MonoBehaviour
{
    GamePadState state;
    GamePadState prevState;
    public PlayerIndex idx;

    public List<Sprite> activatedSprites;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string wool)
    {
        SceneManager.LoadScene(wool);
    }

    private void Update()
    {
        prevState = state;
        state = GamePad.GetState(idx);
        
        if(prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
            if(idx == PlayerIndex.One)
            {
                
            }
        }

    }
}
