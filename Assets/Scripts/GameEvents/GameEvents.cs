using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityAction OnStartWave;
    public static UnityAction OnTowerButtonUseable;
    public static UnityAction OnTowerButtonNotUseable;

    public static void LoadStartWave()
    {
        OnStartWave?.Invoke();
    }

    public static void LoadTowerButtonUseable()
    {
        OnTowerButtonUseable?.Invoke();
    }

    public static void LoadTowerButtonNotUseable()
    {
        OnTowerButtonNotUseable?.Invoke();
    }



}
