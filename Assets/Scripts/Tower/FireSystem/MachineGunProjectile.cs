using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectileDelay());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        
        base.OnTriggerEnter(other);

       
        MachineGunProjectilePool.Instance.ReturnToPool(this);
        

        
    }

    IEnumerator DeactiveProjectileDelay()
    {
        yield return new WaitForSeconds(projectileData.ProjectileStats.LifeTime);
        MachineGunProjectilePool.Instance.ReturnToPool(this);
    }


}
