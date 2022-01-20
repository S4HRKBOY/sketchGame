using UnityEngine;

public abstract class EnemyBaseState 
{
    public abstract void startState(EnemyStateManager manager);
    public abstract void UpdateState(EnemyStateManager manager);



}
