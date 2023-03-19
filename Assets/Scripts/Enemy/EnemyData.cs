using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private int increaseEnergy;

    [SerializeField]
    private GameObject deathEffect;

    [SerializeField]
    private float startHealth;

    public int IncreaseEnergy => increaseEnergy;

    public GameObject DeathEffect => deathEffect;

    public float StartHealth
    {
        get => startHealth;
        set => startHealth = value;
    }


}
