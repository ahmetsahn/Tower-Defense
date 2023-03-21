using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerMove : MonoBehaviour
{
    [SerializeField]
    private Transform towerHead;

    [SerializeField]
    private float rotationTime;


    private Quaternion defaultRotation;

    [SerializeField]
    private bool enemyDetected;
    public bool EnemyDetected => enemyDetected;

    private void Start()
    {
        defaultRotation = towerHead.rotation;
    }

    public void SetRotationToEnemy(GameObject nearestEnemy)
    {


        towerHead.DORotateQuaternion(Quaternion.LookRotation(nearestEnemy.transform.position - towerHead.position), rotationTime);

        if (Vector3.Angle(towerHead.forward, nearestEnemy.transform.position - towerHead.position) < 5f)
        {
            SetEnemyDetected(true);
            SetRotationSpeed(0.01f);
        }
        else
        {
            SetEnemyDetected(false);
            SetRotationSpeed(0.5f);
        }



    }

    public void SetEnemyDetected(bool value)
    {
        enemyDetected = value;
    }

    public void SetRotationSpeed(float newSpeed)
    {
        rotationTime = newSpeed;
    }

    public void SetDefaultRotation()
    {
        rotationTime = 0.5f;
        towerHead.DORotateQuaternion(defaultRotation, rotationTime);
    }

}
