
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumManager : MonoBehaviour {

    public static PlayerNumManager instance;
    public List<GameObject> players;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
	}
	 
    public void RemovePlayer(GameObject playerToBeRemoved)
    {
        players.Remove(playerToBeRemoved);
    }
}
