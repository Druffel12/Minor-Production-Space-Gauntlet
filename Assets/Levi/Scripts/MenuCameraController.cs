using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class MenuCameraController : MonoBehaviour
{
    public Animator anim;

    GamePadState prevState;
    GamePadState state;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        //state = GamePad.GetState()
	}
}
