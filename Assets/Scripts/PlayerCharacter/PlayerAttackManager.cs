using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    //Animation

    const string PLAYER_DEFAULTATTACK = "DefaultAttackAnimation";
    const string PLAYER_STRONGATTACK = "StrongAttackAnimation";
    const string PLAYER_BLOCKPOSE = "BlockPose";
    const string PLAYER_CROSSBOWPOSE = "CrossBowPose";
    const string PLAYER_WHIRLWINDATTACK = "WhirlWindAttackAnimation";
    const string PLAYER_IDLE = "PlayerIdle";

    //Variables
    public PlayerInputSO _playerInput;
    public UpgradeTest _upgradeTest;

    AnimationHandler animationHandler;

    public GameObject attackCollider;
    public GameObject blockColliderObject;
    public Collider2D blockCollider;

    public StatsManager statsManager;
    public LayerMask UpgradeArea;
    public LayerMask whatIsEnemy;

    [SerializeField] float startTimeBtwAttack = 1f;
    [SerializeField] float startTimeBtwStrongAttack = 2f;
    [SerializeField] float startTimeBtwCrossBowShot = 0.5f;
    [SerializeField] float startTimeBtwWhirlWindAttack = 1f;


    [SerializeField] float unlockUpgradeRange;   
    public float attackRadius;
    [SerializeField] float whirlWindRadius;

    [SerializeField] GameObject ArrowObject;
    [SerializeField] GameObject ArrowSpawnObject;

    public int damage = 30;
    public int strongAttackDamage = 60;
    public int whirlWindDamage = 40;

    public SpriteRenderer damagePowerUpIndicator;

    public float defaultAttackStaminaCost = 10f;
    public float strongAttackStaminaCost = 20f;
    public float whirlWindStaminaCost = 25f;
    public float crossBowShotStaminaCost = 10f;
    public float blockingCostPerUpdate;

    private float timeBtwAttack;

    private void OnEnable()
    {
        _playerInput.WhirlWind += whirlWindAttack;
        _playerInput.Shot += crossBowShot;
        _playerInput.StrongAttack += strongAttack;
        _playerInput.DefaultAttack += defaultAttack;
        _playerInput.TriggerEvent += checkForTriggerEvent;
    }

    private void OnDisable()
    {
        _playerInput.WhirlWind -= whirlWindAttack;
        _playerInput.Shot -= crossBowShot;
        _playerInput.StrongAttack -= strongAttack;
        _playerInput.DefaultAttack -= defaultAttack;
        _playerInput.TriggerEvent -= checkForTriggerEvent;       
    }
   
    void Start()
    {
        animationHandler = GetComponentInChildren<AnimationHandler>();
        blockCollider = blockColliderObject.GetComponent<CircleCollider2D>();
        blockCollider.enabled = false;
        statsManager = GetComponent<StatsManager>();
    }
    
    void Update()
    {        
        timeBtwAttack -= Time.deltaTime;
        checkForBlocking();
        if (_playerInput.isBlocking)
        {
            statsManager.stamina -= blockingCostPerUpdate;
        }
    }

    private void defaultAttack()
    {
        
        if (timeBtwAttack <= 0 && statsManager.getStamina() >= defaultAttackStaminaCost)
        {
            FindObjectOfType<AudioManager>().play("NormalAttack");
            animationHandler.changeAnimationState(PLAYER_DEFAULTATTACK);           
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackCollider.transform.position, attackRadius, whatIsEnemy);

            if(enemiesToDamage.Length > 0)
            {
                FindObjectOfType<AudioManager>().play("SwordHitPlayer");
            }
            
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<StatsManager>().takeDamage(damage);
            }
            statsManager.reduceStamina(defaultAttackStaminaCost);
            timeBtwAttack = startTimeBtwAttack;           
        }       
    }

    private void checkForBlocking()
    {
        if (_upgradeTest.upgradeList[0] && timeBtwAttack <= 0 && _playerInput.isBlocking && statsManager.stamina >= blockingCostPerUpdate)
        {
            animationHandler.changeAnimationState(PLAYER_BLOCKPOSE);
            statsManager.reduceStamina(blockingCostPerUpdate);
            blockCollider.enabled = true;
            return;
        }     
        blockCollider.enabled = false;
        
    }
  
    public void strongAttack()
    {
        if (_upgradeTest.upgradeList[1])
        {
            if(timeBtwAttack <= 0 && statsManager.getStamina() >= strongAttackStaminaCost)
            {
                animationHandler.changeAnimationState(PLAYER_STRONGATTACK);                               
                statsManager.reduceStamina(strongAttackStaminaCost);
                timeBtwAttack = startTimeBtwStrongAttack;
            }           
        }       
    }
   
    private void crossBowShot()
    {
        if (_upgradeTest.upgradeList[4] && timeBtwAttack <= 0 && statsManager.getStamina() >= crossBowShotStaminaCost)
        {
            FindObjectOfType<AudioManager>().play("ArrowShot");
            animationHandler.changeAnimationState(PLAYER_CROSSBOWPOSE);            
            statsManager.reduceStamina(crossBowShotStaminaCost);
            Instantiate(ArrowObject, ArrowSpawnObject.transform.position, Quaternion.identity);
            timeBtwAttack = startTimeBtwCrossBowShot;
        }
    }

    private void whirlWindAttack()
    {
        if (_upgradeTest.upgradeList[3] && timeBtwAttack <= 0 && statsManager.getStamina() >= whirlWindStaminaCost)
        {
            FindObjectOfType<AudioManager>().play("AOE_Attack");
            animationHandler.changeAnimationState(PLAYER_WHIRLWINDATTACK);
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, whirlWindRadius, whatIsEnemy);

            if (enemyColliders.Length > 0)
            {
                FindObjectOfType<AudioManager>().play("SwordHitPlayer");
            }

            for (int i = 0; i < enemyColliders.Length; i++)
            {
                enemyColliders[i].GetComponent<StatsManager>().takeDamage(whirlWindDamage);
            }
            statsManager.reduceStamina(whirlWindStaminaCost);
            timeBtwAttack = startTimeBtwWhirlWindAttack;
        }
    }


    private void checkForTriggerEvent()
    {
        Collider2D[] checkColliders = Physics2D.OverlapCircleAll(transform.position, unlockUpgradeRange);
        if (checkColliders.Length > 0)
        {
            for(int i = 0; i < checkColliders.Length; i++)
            {
                //Activate PowerUps
                if (checkColliders[i].gameObject.layer == 14)
                {
                    checkColliders[i].GetComponent<PowerUp>().enablePowerUp();
                    FindObjectOfType<AudioManager>().play("InteractSound");
                }
                   

                if(checkColliders[i].gameObject.layer == 13)
                {
                    
                    //Changing player Spawn Location
                    checkColliders[i].GetComponent<PlayerSpawn>().activatePlayerSpawn();
                }

                if (checkColliders[i].gameObject.layer == 12)
                {
                    //Unlock Doors
                    checkColliders[i].GetComponent<Lever>().corrispondingDoor.unlockAndIncreaseCounter();
                    checkColliders[i].GetComponent<Lever>().anim.SetBool("IsSwitched", true);
                    checkColliders[i].gameObject.layer = 0;
                } 
                //Unlock upgrades
                if (checkColliders[i].gameObject.layer == 7)
                {
                    FindObjectOfType<AudioManager>().play("InteractSound");
                    _upgradeTest.updateTheCounter();
                    checkColliders[i].gameObject.SetActive(false);
                }                                       
            }          
        }
        else
        {
            Debug.Log("Nothing nearBy!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCollider.transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, whirlWindRadius);
    } 
}
