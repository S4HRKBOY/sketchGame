using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossBaseState 
{
    public abstract void startState(BossStateManager manager);
    public abstract void UpdateState(BossStateManager manager);
}
