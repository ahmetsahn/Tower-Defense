using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject nearestEnemy;
    public GameObject NearestEnemy => nearestEnemy;

    private float newEnemyDistance;
    public float NewEnemyDistance => newEnemyDistance;


    public void FindNearestEnemy(TowerData towerData,TowerMove towerMove)
    {
        // Belli bir range içerisine giren düþmanlarý belirle ve daha yakýn bir düþman girip girmediðini kontrol et

        Collider[] colliders = Physics.OverlapSphere(transform.position, towerData.TowerStats.Range);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                newEnemyDistance = Vector3.Distance(transform.position, collider.transform.position);
                if (nearestEnemy == null)
                {
                    towerMove.SetRotationSpeed(0.5f);
                    nearestEnemy = collider.gameObject;
                }
                else if (newEnemyDistance < Vector3.Distance(transform.position, nearestEnemy.transform.position))
                {
                    towerMove.SetRotationSpeed(0.5f);
                    nearestEnemy = collider.gameObject;
                }
            }

            else
            {
                nearestEnemy = null;
            }
        }
    }
}
