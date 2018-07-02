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

    void Update ()
    {
		if(playerNum.players.Count <= 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                SceneManager.LoadScene(lossScene);
            }
        }
	}
}
