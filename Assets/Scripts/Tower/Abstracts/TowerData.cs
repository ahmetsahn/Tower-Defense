using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TowerData")]
public class TowerData : ScriptableObject
{
    [SerializeField]
    private float range;
    
    [SerializeField]
    private float fireRate;

    [SerializeField]
    private int buildCost;
   
    [SerializeField]
    private GameObject buildEffect;

    [SerializeField]
    private AudioClip attackSound;

    [SerializeField]
    private AudioClip buildSound;

    
    
    public float Range => range;

    public float FireRate => fireRate;

    public int BuildCost => buildCost;

    public GameObject BuildEffect => buildEffect;

    public AudioClip AttackSound => attackSound;

    public AudioClip BuildSound => buildSound;



}
