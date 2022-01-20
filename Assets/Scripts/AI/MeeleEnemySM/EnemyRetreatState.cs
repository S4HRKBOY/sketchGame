using UnityEngine;

public class EnemyRetreatState : EnemyBaseState
{
    public override void startState(EnemyStateManager manager)
    {               
        manager.enemyAnimationHandler.playAnimation(manager.WhileWalkingAnimation);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerradius, manager.whatIsPlayer))
            manager.SwtichState(manager.followState);
        if (manager.checkForSpawningLocation(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForSpawingLocationRadius, manager.spawningPoint))
            manager.SwtichState(manager.idleState);

        manager.agent.returnHome();
    }
}
