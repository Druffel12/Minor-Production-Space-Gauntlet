using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats", order = 1)]
public class PlayerStatsObj : ScriptableObject {

    public float speed;
    public float maxHealth;
    public float damage;
    public float range;
    public float timeBetweenShots;
}
