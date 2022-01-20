using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public List<Door> unlockedDoors = new List<Door>();
    public List<GameObject> corrispondingLevers = new List<GameObject>();
    public List<PlayerSpawn> playerSpawningPositions = new List<PlayerSpawn>();
   
    public GameObject player;

    [SerializeField] List<GameObject> unlockableUpgrades = new List<GameObject>();
    private GameObject currentPlayer;

    public SpawnContainer playerSpawningPositionsSO;
    public UpgradeTest upgradeTestSO;
    public DoorsContainer doorsContainerSO;

    public PlayerProgressManager progressManager;

    public PlayerSpawn currentPosition;

    


    //NEEDS TO BE SAVED
    [SerializeField] int unlockedDoorsCounter = 0;
      
    private void Awake()
    {
        unlockedDoorsCounter = doorsContainerSO.DoorsCounterSO;                       
        playerSpawningPositionsSO.initializeSpawnFromIndex();
        setIsActive();
        currentPosition = playerSpawningPositions[playerSpawningPositionsSO.findfirstActive(playerSpawningPositions)];        
               
        upgradeTestSO.initalizeUpgrades();        
        
        
        Instantiate(player, currentPosition.transform.position, currentPosition.transform.rotation);
        initializeUnlockableUpgrades();

    }

    private void Start()
    {
        initializeDoors();
    }

    private void setIsActive()
    {
        for(int i = 0;i < playerSpawningPositions.Count; i++)
        {
            playerSpawningPositions[i].isActive = playerSpawningPositionsSO.playerSpawns[i];

        }
    }

    public void setNewSpawn()
    {
        currentPosition.isActive = false;
        playerSpawningPositionsSO.updateList(playerSpawningPositions);
        currentPosition.anim.SetBool("isActivated", false);
        currentPosition = currentPosition = playerSpawningPositions[playerSpawningPositionsSO.findfirstActive(playerSpawningPositions)];
    }
     
    public void initializeDoors()
    {
        for(int i = 0; i < unlockedDoorsCounter; i++)
        {
            corrispondingLevers[i].layer = 0;
            unlockedDoors[i].unlock();
        }
    }

    public void increaseDoorsCounter()
    {
        doorsContainerSO.DoorsCounterSO++;
        Debug.Log("Door Counter Increased!");
    }
   
    private void initializeUnlockableUpgrades()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        CharacterController charCon = currentPlayer.GetComponent<CharacterController>();

        for(int i = 0; i < unlockableUpgrades.Count; i++)
        {
            if (charCon._upgradeTest.upgradeList[i])
                unlockableUpgrades[i].SetActive(false);
        }

    }

    public void SwitchToEndScene()
    {
        SceneManager.LoadScene("ThankYouScene");
    }
}
