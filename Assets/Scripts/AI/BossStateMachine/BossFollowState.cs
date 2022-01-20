using UnityEngine;

public class BossFollowState : BossBaseState
{
    public override void startState(BossStateManager manager)
    {
        
    }

    public override void UpdateState(BossStateManager manager)
    {
        manager.enemyAnimationHandler.playAnimation(manager.IdleAnimation);

        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius, manager.playerMask))
            manager.SwtichState(manager.attackState);
        
        if(manager.statsManager.health <= manager.statsManager.maxHealth / 2 && !manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius, manager.playerMask))
        {
            manager.SwtichState(manager.healState);
        }

        manager.agent.requestPath();
        manager.agent.adjustRotation();
    }
}
