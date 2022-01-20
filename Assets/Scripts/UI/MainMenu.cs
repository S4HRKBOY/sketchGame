using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] PlayerProgressManager playerProgressManager;

    [SerializeField] UpgradeTest upgradeTest;
    [SerializeField] DoorsContainer doorsContainer;
    [SerializeField] SpawnContainer spawnContainer;
   
    public void startNewRun()
    {
        upgradeTest.upgradeCounter = 0;
        doorsContainer.DoorsCounterSO = 0;
        spawnContainer.currentSpawnIndex = 0;
        SceneManager.LoadScene("LevelOne");
    }

    public void loadPreviousRun()
    {
        if (playerProgressManager.load())
        {
            SceneManager.LoadScene("LevelOne");
        }       
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
