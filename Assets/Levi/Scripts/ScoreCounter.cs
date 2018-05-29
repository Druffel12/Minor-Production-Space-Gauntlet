using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    int score;

    public void ScoreIncrease(int increase)
    {
        score += increase;
        scoreText.text = score.ToString();
    }

	void Start ()
    {
        ScoreIncrease(0);	
	}
}
