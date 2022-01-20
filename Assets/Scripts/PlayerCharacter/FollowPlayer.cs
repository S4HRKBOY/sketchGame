using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] float insideFOV;
    [SerializeField] float outsideFOV;

    [SerializeField] private bool isIncreasing;
    [SerializeField] private bool isDecreasing;

    [SerializeField] float increaseRate;

    public LayerMask player;

    public Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();

        LevelManager levelManager = FindObjectOfType<LevelManager>();

        if(levelManager.playerSpawningPositionsSO.currentSpawnIndex == 4 || levelManager.playerSpawningPositionsSO.currentSpawnIndex == 5)
        {
            camera.fieldOfView = outsideFOV;
        }
        else
        {
            camera.fieldOfView = insideFOV;
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
   
    void Update()
    {
        followPlayer();
        if (isIncreasing)
        {
            camera.fieldOfView += increaseRate;
            if(camera.fieldOfView >= outsideFOV)
            {
                isIncreasing = false;
            }
        }
        if (isDecreasing)
        {
            camera.fieldOfView -= increaseRate;
            if (camera.fieldOfView <= insideFOV)
            {
                isDecreasing = false;
            }
        }
    }

    public void increaseFOV()
    {
        isIncreasing = true;
    }

    public void decreaseFOV()
    {
        isDecreasing = true;
    }

    void followPlayer()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
