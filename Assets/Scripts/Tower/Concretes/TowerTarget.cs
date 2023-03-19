using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject nearestEnemy;
    public GameObject NearestEnemy => nearestEnemy;

    private float closestDistance;
    public float ClosestDistance => closestDistance;


    private void Update()
    {
        FindNearestEnemy();
    }

    public void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        nearestEnemy = null;

        closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                nearestEnemy = enemy;
                closestDistance = distanceToEnemy;
            }

        }
    }

    
}
