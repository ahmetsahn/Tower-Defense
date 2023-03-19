using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float lifeTime;

    [SerializeField]
    private GameObject impactEffect;

    public float Damage => damage;

    public float MoveSpeed => moveSpeed;

    public float LifeTime => lifeTime;

    public GameObject ImpactEffect => impactEffect;

    
}
