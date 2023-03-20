using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityAction OnStartWave;
   

    public static void LoadStartWave()
    {
        OnStartWave?.Invoke();
    }

   
}
