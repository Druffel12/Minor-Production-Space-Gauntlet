using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<ScoreCounter> playerScores;
    public PlayerManager players;

    public ScoreCounter player1Score;
    public ScoreCounter player2Score;
    public ScoreCounter player3Score;
    public ScoreCounter player4Score;


    void Start ()
    {
        playerScores.Add(player1Score);
        playerScores.Add(player2Score);
        playerScores.Add(player3Score);
        playerScores.Add(player4Score);

        DontDestroyOnLoad(gameObject);
	}

    private void Update()
    {
        playerScores.Sort();
    }
}
