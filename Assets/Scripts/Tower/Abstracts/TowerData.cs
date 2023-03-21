using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TowerData")]
public class TowerData : ScriptableObject
{
    [SerializeField]
    private float range;
    public float Range => range;
    
    [SerializeField]
    private float fireRate;
    public float FireRate => fireRate;
    
    [SerializeField]
    private int buildCost;
    public int BuildCost => buildCost;
    
    [SerializeField]
    private GameObject buildEffect;
    public GameObject BuildEffect => buildEffect;

    [SerializeField]
    private AudioClip attackSound;
    public AudioClip AttackSound => attackSound;

    [SerializeField]
    private AudioClip buildSound;
    public AudioClip BuildSound => buildSound;
   














}
