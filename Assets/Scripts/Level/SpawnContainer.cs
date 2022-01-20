using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSpawnContainer")]
public class SpawnContainer : ScriptableObject
{
    public bool[] playerSpawns = new bool[6];

    public int currentSpawnIndex = 0;

    public void updateList(List<PlayerSpawn> spawns)
    {
        for(int i = 0; i < playerSpawns.Length; i++)
        {
            Debug.Log(spawns[i].isActive);
            playerSpawns[i] = spawns[i].isActive;
        }
    }

    public int findfirstActive(List<PlayerSpawn> spawns)
    {
        for(int i = 0; i< playerSpawns.Length; i++)
        {
            if (spawns[i].isActive)
            {
                currentSpawnIndex = i;
                return i;
            }
        }
        return -1;
    }

    public void initializeSpawnFromIndex()
    {
        for(int i= 0; i < playerSpawns.Length; i++)
        {
            if(i == currentSpawnIndex)
            {
                playerSpawns[i] = true;
            }
            else
            {
                playerSpawns[i] = false;
            }
        }
    }
}
