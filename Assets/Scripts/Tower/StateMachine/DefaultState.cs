using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefaultState : ITowerState
{
    public void EnterState(BaseTower tower)
    {
        tower.TowerMove.SetEnemyDetectedFalse();
        tower.TowerMove.SetDefaultRotation();
    }

 
    public void UpdateState(BaseTower tower)
    {
        

        if (tower.TowerTarget.NearestEnemy != null && tower.TowerTarget.ClosestDistance <= tower.TowerData.Range)
        {
            tower.SwitchState(tower.attackState);
        }

        else
        {
            tower.TowerMove.SetDefaultRotation();
        }
    }

    
}
