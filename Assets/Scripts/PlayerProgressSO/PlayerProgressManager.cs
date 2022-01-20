using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class PlayerProgressManager : MonoBehaviour
{

    public SpawnContainer spawnContainer;    
    public UpgradeTest upgradeTest;
    public DoorsContainer doorsContainer;
    
    [Serializable]
    public class PlayerProgressContainer
    {
        public PlayerProgressEntry progressEntry;
    }

    [Serializable]
    public class PlayerProgressEntry
    {
        public int doorsCounterEntry;
        public int spawnIndexEntry;
        public int upgradeCounterEntry;
    }

    private const string FileName = "playerProgress.json";
    private const int maxPlayerProgressEntrys = 1;

    private PlayerProgressEntry _progressEntry = new PlayerProgressEntry();

    private string PlayerProgressFilePath => Path.Combine(Application.persistentDataPath, FileName);

    public void save()
    {
        _progressEntry.doorsCounterEntry = doorsContainer.DoorsCounterSO;
        _progressEntry.spawnIndexEntry = spawnContainer.currentSpawnIndex;
        _progressEntry.upgradeCounterEntry = upgradeTest.upgradeCounter;

        var playerProgressContainer = new PlayerProgressContainer()
        {
            progressEntry = _progressEntry
        };

        var json = JsonUtility.ToJson(playerProgressContainer);
        File.WriteAllText(PlayerProgressFilePath, json);
    }

    public bool load()
    {
        if (!File.Exists(PlayerProgressFilePath))
        {
            return false;
        }
        var json = File.ReadAllText(PlayerProgressFilePath);
        var playerProgressContainer = JsonUtility.FromJson<PlayerProgressContainer>(json);

        if(playerProgressContainer == null || playerProgressContainer.progressEntry == null)
        {
            return false;
        }

        _progressEntry = playerProgressContainer.progressEntry;

        spawnContainer.currentSpawnIndex = _progressEntry.spawnIndexEntry;
        upgradeTest.upgradeCounter = _progressEntry.upgradeCounterEntry;
        doorsContainer.DoorsCounterSO = _progressEntry.doorsCounterEntry;

        return true;
    }


}
