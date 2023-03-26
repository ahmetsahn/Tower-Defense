using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectileDelay());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        LaserProjectilePool.Instance.ReturnToPool(this);
    }

    IEnumerator DeactiveProjectileDelay()
    {
        yield return new WaitForSeconds(projectileData.ProjectileStats.LifeTime);
        LaserProjectilePool.Instance.ReturnToPool(this);
    }
}
