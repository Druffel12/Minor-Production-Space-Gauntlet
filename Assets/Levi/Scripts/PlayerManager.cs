using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<PlayerController> players;
    PlayerSelectManager playerManager;
    UIManager UI;

    void Awake ()
    {
        playerManager = FindObjectOfType<PlayerSelectManager>();
        UI = FindObjectOfType<UIManager>();

        players = new List<PlayerController>(FindObjectsOfType<PlayerController>());
       for (int i = 0; i < players.Count; i++)
        {
            if (playerManager.p1Ready == false)
            {
                if (players[i].name == "Player 1")
                {
                    players[i].gameObject.SetActive(false);
                }
            }
            if (playerManager.p2Ready == false)
            {
                if(players[i].name == "Player 2")
                {
                    players[i].gameObject.SetActive(false);
                }
            }
            if (playerManager.p3Ready == false)
            {
                if (players[i].name == "Player 3")
                {
                    players[i].gameObject.SetActive(false);
                }
            }
            if(playerManager.p4Ready == false)
            {
                if(players[i].name == "Player 4")
                {
                    players[i].gameObject.SetActive(false);
                }
            }
            UI.UIRunThrough();
        }
    }
}
