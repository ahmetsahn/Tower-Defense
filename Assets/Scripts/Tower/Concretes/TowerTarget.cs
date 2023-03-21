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
        // Belli bir range i�erisine giren d��manlar� belirle ve daha yak�n bir d��man girip girmedi�ini kontrol et

        Collider[] colliders = Physics.OverlapSphere(transform.position, towerData.Range);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                newEnemyDistance = Vector3.Distance(transform.position, collider.transform.position);
                if (nearestEnemy == null)
                {
                    nearestEnemy = collider.gameObject;
                }
                else if (newEnemyDistance < Vector3.Distance(transform.position, nearestEnemy.transform.position))
                {
                    nearestEnemy = collider.gameObject;
                    towerMove.SetRotationSpeed(0.5f);
                }
            }

            else
            {
                nearestEnemy = null;
            }
        }
    }
}
