using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealState : BossBaseState
{
    public override void startState(BossStateManager manager)
    {
        manager.timeBtwHeal = manager.startTimeToHeal;
        manager.healLight.SetActive(true);
        manager.enemyAnimationHandler.playAnimation(manager.HealAnimation);
    }

    public override void UpdateState(BossStateManager manager)
    {
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        if (manager.timeBtwHeal <= 0)
        {
            manager.healLight.SetActive(false);
            manager.enemyAnimationHandler.playAnimation(manager.IdleAnimation);
            if (manager.checkForPlayer(manager.transform.position, manager.attackingPlayerRadius, manager.playerMask))
            {
                manager.SwtichState(manager.attackState);
            }
            else
            {
                manager.SwtichState(manager.followState);
            }
        }

       

        if (manager.checkForPlayer(manager.transform.position, manager.playerToCloseRadius, manager.playerMask))
        {
            manager.SwtichState(manager.attackState);
        }

        if(manager.statsManager.health + manager.amountToHealPerUpdateCycle >= manager.statsManager.maxHealth)
        {
            manager.statsManager.health = manager.statsManager.maxHealth;
        }
        else
        {
            manager.statsManager.health += manager.amountToHealPerUpdateCycle;
        }


    }
}
