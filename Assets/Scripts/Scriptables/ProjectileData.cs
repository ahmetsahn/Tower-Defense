using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [SerializeField]
    private ProjectileStats projectileStats;
    public ProjectileStats ProjectileStats => projectileStats;

    [SerializeField]
    private GameObject impactEffect;
    public GameObject ImpactEffect => impactEffect;
}

[Serializable]
public struct ProjectileStats
{
    [SerializeField]
    private float damage;
    public float Damage => damage;
    
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed => moveSpeed;
    
    [SerializeField]
    private float lifeTime;
    public float LifeTime => lifeTime;
}
