using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    public EnemyData EnemyData => enemyData;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private float currentHealth;

    public float CurrentHealth
    {
       get => currentHealth;
       set => currentHealth = value;
    }

    private void Start()
    {
        SetCurrentHealth();
    }

    private void Update()
    {
        enemyMovement.Move(this);
    }

    public void TakeDamage(float damage)
    {
        ReduceCurrentHealth(damage);

        IsDead();
    }

    private void SetCurrentHealth()
    {
        currentHealth = enemyData.EnemyStats.Health;
    }

    private void ReduceCurrentHealth(float damage)
    {
        currentHealth -= damage;
    }

    private void IsDead()
    {
        if (currentHealth <= 0)
        {
            UIController.Instance.IncreaseEnergy(enemyData.EnemyStats.IncreaseEnergy);
            UIController.Instance.UpdateEnergyText();
            ReturnToPool();
            ResetPathIndex();
            ResetHealth();
            LoadDeathEffect();
            
        }
    }

    

    private void ReturnToPool()
    {
        EnemyPool.Instance.ReturnToPool(this);
    }

    private void ResetPathIndex()
    {
        enemyMovement.pathPointsIndex = 0;
    }

    private void ResetHealth()
    {
        currentHealth = enemyData.EnemyStats.Health;
    }

    private void LoadDeathEffect()
    {
        Instantiate(enemyData.DeathEffect, transform.position, Quaternion.identity);
    }

   
        
    

   
}
