using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectile());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        LaserProjectilePool.Instance.ReturnToPool(this);
    }

    IEnumerator DeactiveProjectile()
    {
        yield return new WaitForSeconds(projectileData.LifeTime);
        LaserProjectilePool.Instance.ReturnToPool(this);
    }
}
