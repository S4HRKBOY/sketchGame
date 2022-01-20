using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyShootingState : RangeEnemyBaseState
{
    public override void startState(RangeEnemySM manager)
    {
       
    }

    public override void updateState(RangeEnemySM manager)
    {
        if (!manager.agent.notSearchingAnymore)
            manager.agent.notSearchingAnymore = true;

        if(manager.timeBtwShots <= 0)
        {
            if (manager.checkForPlayer(manager.transform.position, manager.playerTooCloseRadius) && manager.timeBtwEvade <= 0)
            {
                manager.playAnimation(manager.Evade);
                manager.transform.position = manager.RetreatObject.transform.position;
                manager.timeBtwEvade = manager.startTimeBtwEvade;
                return;
            }

            if (!manager.checkForPlayer(manager.transform.position, manager.attackingPlayerRadius))
            {
                manager.SwtichState(manager.followState);
            }

            manager.playAnimation(manager.Shot);            
            manager.timeBtwShots = manager.startTimeBtwShots;
        }

        manager.agent.adjustRotation();
    }
}
