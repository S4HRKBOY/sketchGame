using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{

    [Header("LayerMasks")]
    public LayerMask playerMask;

    public GameObject healLight;

    public Agent agent;
    public StatsManager statsManager;
    public BossAnimationhandler enemyAnimationHandler;

    [Header("Animations")]

    public string IdleAnimation;
    public string DeathAnimation;
    public string SimpleAttackAnimation;
    public string aoeAttackAnimation;
    public string pierceAttackAnimation;
    public string ShootingAnimation;
    public string HealAnimation;

    public string currentAttackAnimation;

    [Header("Attack Hitboxes")]
    public GameObject simpleAttackTransform;
    public GameObject aoeAttackTransform;
    public GameObject pierceAttackTransform;
    public GameObject shootAttackTransform;

    public Vector2 currentAttackTransform;

    [Header("Attack SO's")]
    public Attack_BaseClass simpleAttack;
    public Attack_BaseClass aoeAttack;
    public Attack_BaseClass pierceAttack;
    public Attack_BaseClass shootAttack;

    public Attack_BaseClass currentAttack;

    [Header("Attack Configurations")]
    public BossIdleState idleState = new BossIdleState();
    public BossFollowState followState = new BossFollowState();
    public BossAttackingState attackState = new BossAttackingState();
    public BossHealState healState = new BossHealState();

    BossBaseState currentState;

    public float lookingForPlayerRadius;
    public float attackingPlayerRadius;

    public float closeAttackRadius;
    public float mediumAttackRadius;
    public float playerToCloseRadius; //Used when the boss is Healing
    public int amountToHealPerUpdateCycle;
    [SerializeField] int chanceForAoEAttack;

    public int attackBreak;
    public int attackBreakCounter;

    public float startTimeBtwStateUpdate;
    public float startTimeToHeal;

    public float timeBtwHeal;
    float timeBtwStateUpdate;

    public Attack_BaseClass lastAttack;
    public Queue<Attack_BaseClass> attackQueue = new Queue<Attack_BaseClass>();

    public bool doorClosed = false;
    public GameObject bossDoor;

    private void Start()
    {
        statsManager = GetComponent<StatsManager>();
        agent = GetComponent<Agent>();
        enemyAnimationHandler = GetComponentInChildren<BossAnimationhandler>();

        currentState = idleState;
        currentState.startState(this);
    }

    private void Update()
    {
        timeBtwStateUpdate -= Time.deltaTime;
        timeBtwHeal -= Time.deltaTime;

        if (timeBtwStateUpdate <= 0)
        {
            if(currentState != null)
            {
                currentState.UpdateState(this);
                timeBtwStateUpdate = startTimeBtwStateUpdate;
            }         
        }
    }

    public void SwtichState(BossBaseState state)
    {
        currentState = state;
        currentState.startState(this);      
    }

    public bool checkForPlayer(Vector2 worldPosition, float radius, LayerMask whatIsPlayer)
    {
        Collider2D[] playerCheck = Physics2D.OverlapCircleAll(worldPosition, radius, whatIsPlayer);
        if (playerCheck.Length > 0)
            return true;
        return false;
    }

    public void onDeath()
    {
        currentState = null;
        enemyAnimationHandler.playAnimation(DeathAnimation);

    }

    public void EnqueueNextAttack()
    {
        lastAttack = currentAttack;
        if (checkForPlayer(transform.position, closeAttackRadius, playerMask))
        {
            int randomNumber = Random.Range(0, 100);
            if(randomNumber <= chanceForAoEAttack)
            {
                attackQueue.Enqueue(aoeAttack);
                return;
            }
            attackQueue.Enqueue(simpleAttack);
            return;
        }
        
        if(checkForPlayer(transform.position, mediumAttackRadius, playerMask))
        {
            attackQueue.Enqueue(pierceAttack);
            return;
        }       
        attackQueue.Enqueue(shootAttack);          
    }   
    
}
