using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DefaultState : ITowerState
{
    public void EnterState(BaseTower tower)
    {
        Debug.Log("Enter Default State");
        tower.TowerMove.SetDefaultRotation();
    }


    public void UpdateState(BaseTower tower)
    {

        if (tower.TowerTarget.NearestEnemy != null)
        {
            tower.SwitchState(tower.attackState);
        }

        else
        {
            tower.TowerMove.SetDefaultRotation();
            tower.TowerTarget.FindNearestEnemy(tower.TowerData,tower.TowerMove);
        }
    }


}
