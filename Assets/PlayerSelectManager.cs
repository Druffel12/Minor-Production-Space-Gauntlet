using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class PlayerSelectManager : MonoBehaviour
{
     
    
    public bool p1Ready;
    public bool p2Ready;
    public bool p3Ready;
    public bool p4Ready;
    public bool test;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}


    public void updatePlayerSelectManager(PlayerIndex player, bool state)
    {
        switch (player)
        {
            case PlayerIndex.One:
                p1Ready = state;
                break;

            case PlayerIndex.Two:
                p2Ready = state;
                break;

            case PlayerIndex.Three:
                p3Ready = state;
                break;

            case PlayerIndex.Four:
                p4Ready = state;
                break;           
        }
    }


	
	// Update is called once per frame
	void Update ()
    {

		if(test)
        {
            test = false;
            SceneManager.LoadScene("Scene 1");
        }
	}
}
