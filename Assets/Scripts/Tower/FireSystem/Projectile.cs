using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileData projectileData;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(projectileData.ProjectileStats.Damage);
        }

        
        Instantiate(projectileData.ImpactEffect, transform.position, Quaternion.identity);
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * projectileData.ProjectileStats.MoveSpeed * Time.deltaTime);
    }


}
