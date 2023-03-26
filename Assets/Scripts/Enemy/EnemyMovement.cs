using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    public int pathPointsIndex { get; set; }


    public void Move(Enemy enemy)
    {
        transform.position = Vector3.MoveTowards(transform.position, TransformLists.Instance.pathPointsList[pathPointsIndex].position, movementSpeed * Time.deltaTime);

        Vector3 direction = TransformLists.Instance.pathPointsList[pathPointsIndex].position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, TransformLists.Instance.pathPointsList[pathPointsIndex].position) < 0.1f)
        {
            if (pathPointsIndex < TransformLists.Instance.pathPointsList.Count - 1)
            {
                pathPointsIndex++;
            }
            
            else
            {
                EnemyPool.Instance.ReturnToPool(enemy);
                pathPointsIndex = 0;
                enemy.CurrentHealth = enemy.EnemyData.EnemyStats.Health;
                UIController.Instance.ReduceHealth();
                UIController.Instance.UpdateHealthText();
            }

        }
    }
}
