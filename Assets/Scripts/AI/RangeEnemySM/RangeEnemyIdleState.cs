using UnityEngine;

public class RangeEnemyIdleState : RangeEnemyBaseState
{
    public override void startState(RangeEnemySM manager)
    {
        manager.playAnimation(manager.Idle);
       
    }

    public override void updateState(RangeEnemySM manager)
    {
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;
        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerRadius))
            manager.SwtichState(manager.followState);
        

    }   
}
