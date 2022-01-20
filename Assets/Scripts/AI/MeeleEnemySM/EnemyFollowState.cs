using UnityEngine;

public class EnemyFollowState : EnemyBaseState
{
    public override void startState(EnemyStateManager manager)
    {       
        manager.enemyAnimationHandler.playAnimation(manager.WhileWalkingAnimation);
    }

    public override void UpdateState(EnemyStateManager manager)
    {        
        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius, manager.whatIsPlayer))
            manager.SwtichState(manager.attackState);

        if (!manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerradius, manager.whatIsPlayer))
        {            
            manager.SwtichState(manager.retreatState);           
        }       
        manager.agent.requestPath();
        manager.agent.adjustRotation();
                 
    }
}
