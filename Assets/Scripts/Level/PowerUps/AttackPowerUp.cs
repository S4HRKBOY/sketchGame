using UnityEngine;

public class AttackPowerUp : PowerUp
{
    private bool powerUpEnabled;

    [SerializeField] float startTimeBtwUpgrade;
    
    [SerializeField] SpriteRenderer light;
    [SerializeField] SpriteRenderer icon;

    [SerializeField] LayerMask playerMask;
    [SerializeField] int extraDamageFactor;

    PlayerAttackManager manager;


    private void Update()
    {
        if (powerUpEnabled)
        {
            startTimeBtwUpgrade -= Time.deltaTime;

            if(startTimeBtwUpgrade <= 0)
            {
                manager.damagePowerUpIndicator.enabled = false;
                manager.damage /= extraDamageFactor;
                manager.strongAttackDamage /= extraDamageFactor;
                manager.whirlWindDamage /= extraDamageFactor;
                Destroy(gameObject);
            }
        }
    }

    public override void enablePowerUp()
    {       
        if (!powerUpEnabled)
        {
            Debug.Log("Got Damage Power Up!");

            light.enabled = false;
            icon.enabled = false;
            powerUpEnabled = true;

            Collider2D lookingForPlayer = Physics2D.OverlapCircle(transform.position, 5f, playerMask);
            manager = lookingForPlayer.GetComponent<PlayerAttackManager>();
            
            manager.damagePowerUpIndicator.enabled = true;
            manager.damage *= extraDamageFactor;
            manager.strongAttackDamage *= extraDamageFactor;
            manager.whirlWindDamage *= extraDamageFactor;                       
        }       
    }
 

    
}
