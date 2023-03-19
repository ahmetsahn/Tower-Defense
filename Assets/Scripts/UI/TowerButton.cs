using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private int energyCost;

    public int EnergyCost => energyCost;

    [SerializeField]
    private GameObject towerPrefab;

    public void SelectTower()
    {
        towerPrefab.SetActive(true);
        GameEvents.LoadTowerButtonNotUseable();
    }

}
   
