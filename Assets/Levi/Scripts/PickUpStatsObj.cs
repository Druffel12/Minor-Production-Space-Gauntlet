using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpStats", menuName = "PickUpStats", order = 1)]
public class PickUpStatsObj : ScriptableObject
{
    public float healthIncrease;
    public int scoreIncrease1;
    public int scoreIncrease2;
    public int scoreIncrease3;
}
