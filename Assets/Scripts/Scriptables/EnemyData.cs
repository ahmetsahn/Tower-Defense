using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private EnemyStats enemyStats;
    public EnemyStats EnemyStats => enemyStats;

    [SerializeField]
    private GameObject deathEffect;
    public GameObject DeathEffect => deathEffect;
}

[Serializable]
public struct EnemyStats
{
    [SerializeField]
    private float health;
    public float Health => health;

    [SerializeField]
    private int increaseEnergy;
    public int IncreaseEnergy => increaseEnergy;
}
