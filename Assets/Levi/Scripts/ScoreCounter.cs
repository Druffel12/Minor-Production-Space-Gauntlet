using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreCounter : MonoBehaviour, IComparable<ScoreCounter>
{
    public Text scoreText;
    public int score;

    public void ScoreIncrease(int increase)
    {
        score += increase;
        scoreText.text = "Score: " + score.ToString();
    }


    public int CompareTo(ScoreCounter other)
    {
        if(other.score < score)
        {
            return -1;
        }

        if(other.score > score)
        {
            return 1;
        }

        return 0;
    }

	void Start ()
    {
        ScoreIncrease(0);	
	}
}
