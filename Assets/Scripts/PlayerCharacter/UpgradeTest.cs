using UnityEngine;

[CreateAssetMenu(menuName = "UpgradeTester")]
public class UpgradeTest : ScriptableObject
{       
    public bool[] upgradeList = new bool[5];

    //UpgradeList[0] canUseBlock;
    //UpgradeList[1] canUseStrongAttack;
    //UpgradeList[2] canUseEvade;    
    //UpgradeList[3] AOEATTACK
    //UpgradeList[4] RangeAttack

    //This needs to be saved!
    public int upgradeCounter = 0;

    public int updateTheCounter()
    {
        upgradeList[upgradeCounter] = true;
        upgradeCounter++;
        return upgradeCounter;
    }
   
    //SceneLoading/Persistence Saving
    public void initalizeUpgrades()
    {
        for(int i = 0; i < upgradeCounter; i++)
        {
            upgradeList[i] = true;
        }
    }

}
