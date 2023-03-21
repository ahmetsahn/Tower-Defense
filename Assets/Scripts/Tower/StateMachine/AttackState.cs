using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackState : ITowerState
{
    public void EnterState(BaseTower tower)
    {
        Debug.Log("Enter Attack State");
    }

    public void UpdateState(BaseTower tower)
    {


        if (tower.TowerTarget.NearestEnemy == null)
        {
            tower.SwitchState(tower.defaultState);
        }

        else
        {
            tower.TowerMove.SetRotationToEnemy(tower.TowerTarget.NearestEnemy);
            tower.TowerTarget.FindNearestEnemy(tower.TowerData, tower.TowerMove);
            tower.Attack();
        }


    }
}
