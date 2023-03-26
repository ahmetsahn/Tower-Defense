using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    [SerializeField]
    private TowerData towerData;
    public TowerData TowerData => towerData;

    [SerializeField]
    private TowerMove towerMove;
    public TowerMove TowerMove => towerMove;

    [SerializeField]
    private TowerTarget towerTarget;
    public TowerTarget TowerTarget => towerTarget;

    [SerializeField]
    private Transform projectileSpawnPoint;
    public Transform ProjectileSpawnPoint => projectileSpawnPoint;

    [SerializeField]
    protected ITowerState currentState;
    
    public DefaultState defaultState = new DefaultState();
    
    public AttackState attackState = new AttackState();

    protected bool canFire = true;

    protected void Start()
    {
        BuildEffect();
        
        PlayBuildSound(towerData);
        
        currentState = defaultState;
    }

    protected void Update()
    {
        currentState.UpdateState(this);
    }

    private void BuildEffect()
    {
        Instantiate(towerData.BuildEffect, transform);
    }
    
    public virtual void Attack()
    {
        if (towerMove.EnemyDetected && canFire)
        {
            canFire = false;
            InstantiateProjectile();
            PlayAttackSound(towerData);
            StartCoroutine(AttackDelay());
        }
    }

    protected abstract void InstantiateProjectile();

    protected IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(towerData.TowerStats.FireRate);
        canFire = true;
    }

    public void SwitchState(ITowerState newState)
    {
        currentState = newState;
        currentState?.EnterState(this);
    }

    public void PlayBuildSound(TowerData towerData)
    {
        AudioManager.Instance.PlaySound(towerData.BuildSound,transform.position,1);
    }

    public void PlayAttackSound(TowerData towerData)
    {
        AudioManager.Instance.PlaySound(towerData.AttackSound,transform.position,1);
    }
}    
   
