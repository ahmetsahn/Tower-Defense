using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileData projectileData;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>()!=null)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(projectileData.Damage);
        }

        
        Instantiate(projectileData.ImpactEffect, transform.position, Quaternion.identity);
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * projectileData.MoveSpeed * Time.deltaTime);
    }
}
