using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject enemySpawnObject;
    [SerializeField] int maxEnemiesToSpawn;

    [SerializeField] LayerMask enemyMask;
    [SerializeField] LayerMask unwalkableMask;
    
    [SerializeField] float spawnRadius;
    [SerializeField] float checkForUnwalkableRadius = 3;

    [SerializeField] float startTimeBtwSpawn;
    private float timeBtwSpawn;

    private int spawnCounter = 0;

    private void Update()
    {
        timeBtwSpawn -= Time.deltaTime;
        spawnLoop();
    }


    private void spawnLoop()
    {
        if(timeBtwSpawn <= startTimeBtwSpawn)
        {
            spawnNewEntity();
            checkForEnemyCount();
        }        
    }
    private void spawnNewEntity()
    {
        if(spawnCounter < maxEnemiesToSpawn && timeBtwSpawn <= 0)
        {
            float x = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
            float y = Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius);

            bool validPosition = checkIfPositionIsValid(x, y);

            while (!validPosition)
            {
                x = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
                y = Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius);
                validPosition = checkIfPositionIsValid(x, y);
            }


            Instantiate(enemySpawnObject, new Vector3(x, y, 0), Quaternion.identity);
            Instantiate(enemyToSpawn, new Vector3(x,y,0),Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            spawnCounter++;
        }
    }
    private void checkForEnemyCount()
    {
        Collider2D[] enemiesinArea = Physics2D.OverlapCircleAll(transform.position, spawnRadius, enemyMask);        
        while(enemiesinArea.Length < spawnCounter && spawnCounter >= 0)
            spawnCounter--;
    }

    private bool checkIfPositionIsValid(float x,float y)
    {
        Collider2D[] checkingForUnwalkable = Physics2D.OverlapCircleAll(new Vector3(x, y, 0), checkForUnwalkableRadius,unwalkableMask);
        if (checkingForUnwalkable.Length > 0)
            return false;
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);

    }

}
