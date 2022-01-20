using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] int amountToHeal;

    public override void enablePowerUp()
    {
        Debug.Log("Got Health Power Up!");

        Collider2D lookingForPlayer = Physics2D.OverlapCircle(transform.position, 5f, playerMask);
        StatsManager playerStatsManager = lookingForPlayer.GetComponent<StatsManager>();       
        if(playerStatsManager.health + amountToHeal > playerStatsManager.maxHealth)
        {
            playerStatsManager.health = playerStatsManager.maxHealth;
            Destroy(gameObject);
        }
        else
        {
            playerStatsManager.health += amountToHeal;
            Destroy(gameObject);
        }      
    }
}
