﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> players;

    public List<RectTransform> uiElements;

    int counter = 0;

	// Use this for initialization
	void Start ()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        for (int i = 0; i < uiElements.Count; i++)
        {
            uiElements[i].gameObject.SetActive(false);
        }
        UIRunThrough();
        
    }

	public void UIRunThrough()
    {
        counter = 0;

        for (int i = 0; i < players.Count; i++)
        {
            uiElements[i].gameObject.SetActive(true);
            if (players[i] != null)
            {
                counter++;
            }
        }

        if (counter == 1)
        {
            uiElements[0].transform.position = new Vector3(Screen.width / 2, Screen.height / 10, 0);
        }
        else if (counter == 2)
        {
            uiElements[0].transform.position = new Vector3(Screen.width / 4, Screen.height / 10, 0);
            uiElements[1].transform.position = new Vector3(Screen.width * .75f, Screen.height / 10, 0);
        }
        else if(counter == 3)
        {
            uiElements[0].transform.position = new Vector3(Screen.width / 6, Screen.height / 10, 0);
            uiElements[1].transform.position = new Vector3(Screen.width / 2, Screen.height / 10, 0);
            uiElements[2].transform.position = new Vector3(Screen.width * 5 / 6, Screen.height / 10, 0);
        }
        else if(counter == 4)
        {
            uiElements[0].transform.position = new Vector3(Screen.width / 8, Screen.height / 10, 0);
            uiElements[1].transform.position = new Vector3(Screen.width * 3/8,Screen.height/10, 0);
            uiElements[2].transform.position = new Vector3(Screen.width * 5/ 8,Screen.height/10, 0);
            uiElements[3].transform.position = new Vector3(Screen.width * 7/8, Screen.height / 10, 0);
        }
    }
}
