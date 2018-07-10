using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossState : MonoBehaviour
{
    PlayerNumManager playerNum;

    public string lossScene;
    public float counter;

    private void Start()
    {
        playerNum = GetComponent<PlayerNumManager>();   
    }

    bool PlayersAlive()
    {
       for(int i = 0; i < playerNum.players.Count; i++)
        {
            if (playerNum.players[i].activeInHierarchy == true)
            {
                return false;
            }
        }
        return true;
    }

    void Update ()
    {
		if(PlayersAlive())
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                SceneManager.LoadScene(lossScene);
            }
        }
	}
}
