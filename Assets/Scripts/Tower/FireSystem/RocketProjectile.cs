using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectileDelay());
    }

    protected override void OnTriggerEnter(Collider other)
    {

        base.OnTriggerEnter(other);


        RocketProjectilePool.Instance.ReturnToPool(this);



    }

    IEnumerator DeactiveProjectileDelay()
    {
        yield return new WaitForSeconds(projectileData.ProjectileStats.LifeTime);
        RocketProjectilePool.Instance.ReturnToPool(this);
    }
}
