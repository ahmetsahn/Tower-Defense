using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTower : BaseTower
{
    protected override void InstantiateProjectile()
    {
        var projectile = RocketProjectilePool.Instance.Get();
        projectile.transform.position = ProjectileSpawnPoint.position;
        projectile.transform.rotation = ProjectileSpawnPoint.rotation;
        projectile.gameObject.SetActive(true);
    }
}
