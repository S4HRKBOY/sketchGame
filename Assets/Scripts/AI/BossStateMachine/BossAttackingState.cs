using UnityEngine;
using System.Collections;

public class BossAttackingState : BossBaseState
{
    public override void startState(BossStateManager manager)
    {
        if (!manager.doorClosed)
        {
            manager.doorClosed = true;
            manager.bossDoor.GetComponent<Collider2D>().enabled = true;
            manager.bossDoor.GetComponent<Animator>().SetBool("isOpened", false);            
        }
        if(manager.lastAttack != manager.shootAttack)
        {
            manager.attackBreakCounter = 0;
        }        
    }

    public override void UpdateState(BossStateManager manager)
    {
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        manager.EnqueueNextAttack();

        if(manager.lastAttack == manager.shootAttack)
        {
            manager.SwtichState(manager.followState);
        }

        if (!manager.checkForPlayer(new Vector2(manager.transform.position.x, manager.transform.position.y), manager.attackingPlayerRadius, manager.playerMask))
            manager.SwtichState(manager.followState);

        if(manager.attackBreakCounter < manager.attackBreak)
        {
            manager.agent.adjustRotation();
            manager.currentAttack = manager.attackQueue.Dequeue();

            if (manager.currentAttack == manager.simpleAttack)
            {
                manager.currentAttackAnimation = manager.SimpleAttackAnimation;
                manager.currentAttackTransform = manager.simpleAttackTransform.transform.position;
            }
            else if (manager.currentAttack == manager.aoeAttack)
            {
                manager.currentAttackAnimation = manager.aoeAttackAnimation;
                manager.currentAttackTransform = manager.aoeAttackTransform.transform.position;
            }
            else if (manager.currentAttack == manager.pierceAttack)
            {
                manager.currentAttackAnimation = manager.pierceAttackAnimation;
                manager.currentAttackTransform = manager.pierceAttackTransform.transform.position;
            }
            else
            {
                manager.currentAttackAnimation = manager.ShootingAnimation;
                manager.currentAttackTransform = manager.shootAttackTransform.transform.position;
            }                                              
            manager.enemyAnimationHandler.playAnimation(manager.currentAttackAnimation);
            manager.attackBreakCounter++;            
        }
        else
        {
            manager.attackBreakCounter = 0;
            manager.enemyAnimationHandler.playAnimation(manager.IdleAnimation);
            manager.agent.adjustRotation();
        }                 
    }
}
