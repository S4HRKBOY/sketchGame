using UnityEngine;

public class RangeEnemyRetreatState : RangeEnemyBaseState
{
    public override void startState(RangeEnemySM manager)
    {
        
    }

    public override void updateState(RangeEnemySM manager)
    {
        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerRadius))
            manager.SwtichState(manager.followState);
                    
        if (manager.checkForSpawningLocation(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForSpawingLocationRadius))
            manager.SwtichState(manager.idleState);
                   
        manager.agent.returnHome();
    }
}
