using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public PlayerNumManager playerNum;
    public float counter;

    List<GameObject> players;
    public string winScene;
    bool startCounter = false;
    float startingCounter;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            players.Add(other.gameObject);

            if(players.Count == playerNum.players.Count)
            {
                startCounter = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            players.Remove(other.gameObject);
            counter = startingCounter;
        }
    }

    private void Start()
    {
        startingCounter = counter;
        players = new List<GameObject>();
    }

    private void Update()
    {
        if(startCounter == true)
        {
            counter -= Time.deltaTime;
            if(counter <= 0)
            {
              SceneManager.LoadScene(winScene);
            }
        }
    }
}
