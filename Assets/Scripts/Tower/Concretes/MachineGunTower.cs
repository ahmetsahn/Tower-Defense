using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTower : BaseTower
{
  
    protected override void InstantiateProjectile()
    {
        var projectile = MachineGunProjectilePool.Instance.Get();
        projectile.transform.position = ProjectileSpawnPoint.position;
        projectile.transform.rotation = ProjectileSpawnPoint.rotation;
        projectile.gameObject.SetActive(true); 
    }

}
