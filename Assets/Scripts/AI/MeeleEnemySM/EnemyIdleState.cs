using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void startState(EnemyStateManager manager)
    {                
        manager.enemyAnimationHandler.playAnimation(manager.IdleAnimation);
    }

    public override void UpdateState(EnemyStateManager manager)
    {        
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        if (manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.lookingForPlayerradius, manager.whatIsPlayer))
            manager.SwtichState(manager.followState);        
    }
   
}
