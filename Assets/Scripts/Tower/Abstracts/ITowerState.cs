using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerState
{
    void EnterState(BaseTower tower);
    void UpdateState(BaseTower tower);
}
