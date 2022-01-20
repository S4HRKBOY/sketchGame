using UnityEngine;

public class BossIdleState : BossBaseState
{
    public override void startState(BossStateManager manager)
    {
        
    }

    public override void UpdateState(BossStateManager manager)
    {
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerRadius, manager.playerMask))
            manager.SwtichState(manager.followState);
    }
}
