using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShadow : MonoBehaviour
{
    [SerializeField]
    private TowerShadowMove towerShadowMove;

    [SerializeField]
    private GameObject tower;

    private void OnEnable()
    {
        towerShadowMove.Move();
    }

    private void Update()
    {
        towerShadowMove.Move();

        RightClickControl();
        BuildPointTransformControl();

    }

    

   

    private void BuildPointTransformControl()
    {
        
            foreach (Transform target in TransformLists.Instance.buildPointsTransform)
            {
                if (Vector3.Distance(transform.position, target.position) < 3f)
                {
                    
                    SetTransform(target);
                    LeftClickControl(target);

                    break;
                }

                else
                {
                    
                    SetRotationDefault();
                }
            }
        
    }

    private void RightClickControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeactiveTowerShadow();
            UIController.Instance.TowerButtonsUseable();
        }
    }

    private void LeftClickControl(Transform target)
    {
        if (Input.GetMouseButtonDown(0))
        {
            InstantiateTower();

            DeactiveTowerShadow();

            TransformLists.Instance.buildPointsTransform.Remove(target);
        }
    }


    private void DeactiveTowerShadow()
    {
        gameObject.SetActive(false);
    }

    private void SetRotationDefault()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
    private void InstantiateTower()
    {
        var newTower = Instantiate(tower);
        newTower.transform.position = transform.position;
        newTower.transform.rotation = transform.rotation;
        UIController.Instance.ReduceEnergy(newTower.GetComponent<BaseTower>().TowerData.BuildCost);
        UIController.Instance.UpdateEnergyText();
    }

    private void SetTransform(Transform target)
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = newPos;
        transform.rotation = target.rotation;
    }

   
}
