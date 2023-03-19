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
        currentHealth = enemyData.StartHealth;
    }

    private void ReduceCurrentHealth(float damage)
    {
        currentHealth -= damage;
    }

    private void IsDead()
    {
        if (currentHealth <= 0)
        {
            ReturnToPool();
            ResetPathIndex();
            ResetHealth();
            LoadDeathEffect();
            IncreaseEnergy();
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
        currentHealth = enemyData.StartHealth;
    }

    private void LoadDeathEffect()
    {
        Instantiate(enemyData.DeathEffect, transform.position, Quaternion.identity);
    }

    private void IncreaseEnergy()
    {
        UIController.Instance.IncreaseEnergy(enemyData.IncreaseEnergy);
        UIController.Instance.UpdateEnergyText();
    }

   
}
