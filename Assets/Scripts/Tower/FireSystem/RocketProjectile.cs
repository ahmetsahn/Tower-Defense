using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectile
{
    private void OnEnable()
    {
        StartCoroutine(DeactiveProjectile());
    }

    protected override void OnTriggerEnter(Collider other)
    {

        base.OnTriggerEnter(other);


        RocketProjectilePool.Instance.ReturnToPool(this);



    }

    IEnumerator DeactiveProjectile()
    {
        yield return new WaitForSeconds(projectileData.LifeTime);
        RocketProjectilePool.Instance.ReturnToPool(this);
    }
}
