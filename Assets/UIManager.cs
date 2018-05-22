using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> players;

    public List<GameObject> uiElements;

    int counter = 0;

	// Use this for initialization
	void Start ()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        for (int i = 0; i < uiElements.Count; i++)
        {
            uiElements[i].SetActive(false);
        }
        UIRunThrough();
        
    }
	
	void UIRunThrough()
    {
        for (int i = 0; i < players.Count; i++)
        {
            uiElements[i].SetActive(true);
            
            counter++;
        }
        
    }
}
