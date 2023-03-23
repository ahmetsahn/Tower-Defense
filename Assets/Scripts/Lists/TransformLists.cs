using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformLists : MonoBehaviour
{
    public static TransformLists Instance { get; private set; }

    public List<Transform> pathPointsList = new List<Transform>();

    public List<Transform> buildPointsTransform = new List<Transform>();
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
