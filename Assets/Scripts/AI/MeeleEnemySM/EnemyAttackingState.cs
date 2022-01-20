using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    public override void startState(EnemyStateManager manager)
    {
        
    }

    public override void UpdateState(EnemyStateManager manager)
    {        
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        if (!manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius, manager.whatIsPlayer))       
              manager.SwtichState(manager.followState);

        //TODO MoreStates: Retreat/Stunned
        if (manager.statsManager.getStamina() <= manager.staminaCostForAttack)
        {
            
           
        }
            
        if(manager.timeBtwAttacks <= 0)
        {           
            float chanceForHeavyAttack = Random.Range(0, 100);
            
            if(chanceForHeavyAttack <= manager.chanceForHeavyAttack)
            {
                
                manager.setCurrentAttack(manager.strongAttack);
                manager.currentHitboxTransform = manager.heavyAttackHitbox.transform.position;
                manager.enemyAnimationHandler.playAnimation(manager.StrongAttackAnimation);
                manager.statsManager.reduceStamina(manager.staminaCostForHeavyAttack);
                manager.agent.adjustRotation();
                return;
                
            }          
            
            manager.setCurrentAttack(manager.basicAttack);
            manager.currentHitboxTransform = manager.attackHitbox.transform.position;
            manager.enemyAnimationHandler.playAnimation(manager.AttackAnimation);
            manager.statsManager.reduceStamina(manager.staminaCostForAttack);
            manager.agent.adjustRotation();            
        }

    }   

}
