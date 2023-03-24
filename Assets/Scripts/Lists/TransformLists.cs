using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransformLists : Singleton<TransformLists>
{
    public List<Transform> pathPointsList = new List<Transform>();

    public List<Transform> buildPointsTransform = new List<Transform>();
    
}
