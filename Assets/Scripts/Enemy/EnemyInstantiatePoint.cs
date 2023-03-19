using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiatePoint : MonoBehaviour
{
    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();
    

    private void StartWave()
    {
        InvokeRepeating("InstantiateEnemy", 0, 7);
    }

    public void InstantiateEnemy()
    {
        var enemy = EnemyPool.Instance.Get();
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
    }

    private void AddListeners()
    {
        GameEvents.OnStartWave += StartWave;
    }

    private void RemoveListeners()
    {
        GameEvents.OnStartWave -= StartWave;
    }
}
