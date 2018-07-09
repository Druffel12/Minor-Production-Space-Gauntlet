using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public Material player1;
    public Material player2;
    public Material player3;
    public Material player4;

    ScoreManager scoreManager;

    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;


    public void AssignMaterial()
    {
            if(scoreManager.playerScores[0] == scoreManager.player1Score)
            {
                first.GetComponent<Renderer>().material = player1;
            }
            else if (scoreManager.playerScores[1] == scoreManager.player1Score)
            {
                second.GetComponent<Renderer>().material = player1;
            }
            else if (scoreManager.playerScores[2] == scoreManager.player1Score)
            {
                third.GetComponent<Renderer>().material = player1;
            }
            else if (scoreManager.playerScores[3] == scoreManager.player1Score)
            {
                fourth.GetComponent<Renderer>().material = player1;
            }

            if (scoreManager.playerScores[0] == scoreManager.player2Score)
            {
                first.GetComponent<Renderer>().material = player2;
            }
            else if (scoreManager.playerScores[1] == scoreManager.player2Score)
            {
                second.GetComponent<Renderer>().material = player2;
            }
            else if (scoreManager.playerScores[2] == scoreManager.player2Score)
            {
                third.GetComponent<Renderer>().material = player2;
            }
            else if (scoreManager.playerScores[3] == scoreManager.player2Score)
            {
                fourth.GetComponent<Renderer>().material = player2;
            }

            if (scoreManager.playerScores[0] == scoreManager.player3Score)
            {
                first.GetComponent<Renderer>().material = player3;
            }
            else if (scoreManager.playerScores[1] == scoreManager.player3Score)
            {
                second.GetComponent<Renderer>().material = player3;
            }
            else if (scoreManager.playerScores[2] == scoreManager.player3Score)
            {
                third.GetComponent<Renderer>().material = player3;
            }
            else if (scoreManager.playerScores[3] == scoreManager.player3Score)
            {
                fourth.GetComponent<Renderer>().material = player3;
            }

            if (scoreManager.playerScores[0] == scoreManager.player4Score)
            {
                first.GetComponent<Renderer>().material = player4;
            }
            else if (scoreManager.playerScores[1] == scoreManager.player4Score)
            {
                second.GetComponent<Renderer>().material = player4;
            }
            else if (scoreManager.playerScores[2] == scoreManager.player4Score)
            {
                third.GetComponent<Renderer>().material = player4;
            }
            else if (scoreManager.playerScores[3] == scoreManager.player4Score)
            {
                fourth.GetComponent<Renderer>().material = player1;
            }
    }


    void Start ()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        AssignMaterial();
	}
}
