using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectile());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        
        base.OnTriggerEnter(other);

       
        MachineGunProjectilePool.Instance.ReturnToPool(this);
        

        
    }

    IEnumerator DeactiveProjectile()
    {
        yield return new WaitForSeconds(projectileData.LifeTime);
        MachineGunProjectilePool.Instance.ReturnToPool(this);
    }


}
