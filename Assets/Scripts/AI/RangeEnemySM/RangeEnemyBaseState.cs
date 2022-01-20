using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeEnemyBaseState 
{
    public abstract void startState(RangeEnemySM manager);

    public abstract void updateState(RangeEnemySM manager);

}
