using UnityEngine;

public class RangeEnemyFollowState : RangeEnemyBaseState
{
    public override void startState(RangeEnemySM manager)
    {
        manager.playAnimation(manager.ReadyToShot);
        
    }

    public override void updateState(RangeEnemySM manager)
    {
        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius))
            manager.SwtichState(manager.shootingState);
                   

        if (!manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerRadius))
            manager.SwtichState(manager.retreatState);
                              
        manager.agent.requestPath();
        manager.agent.adjustRotation();
    }
}
