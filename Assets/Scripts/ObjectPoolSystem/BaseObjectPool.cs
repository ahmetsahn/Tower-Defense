using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObjectPool<T> : MonoBehaviour where T : Component
{
    public static BaseObjectPool<T> Instance { get; private set; }

    [SerializeField]
    private T prefab;

    private Queue<T> objectPool = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if (objectPool.Count == 0)
        {
            AddObjects();
        }

        return objectPool.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);
    }

    private void AddObjects()
    {
      
        T newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objectPool.Enqueue(newObject);
        
    }
}
