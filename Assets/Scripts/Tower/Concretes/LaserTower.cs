using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : BaseTower
{
   
    protected override void InstantiateProjectile()
    {
        var projectile = LaserProjectilePool.Instance.Get();
        projectile.transform.position = ProjectileSpawnPoint.position;
        projectile.transform.rotation = ProjectileSpawnPoint.rotation;
        projectile.gameObject.SetActive(true);
    }
}
