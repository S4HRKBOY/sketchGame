using System.Collections;
using UnityEngine;


//States for the basic meele enemy with one Normal and one Heavy Attack!
public class EnemyStateManager : MonoBehaviour
{
    public Agent agent;
    public StatsManager statsManager;
    public EnemyAnimationHandler enemyAnimationHandler;
    
    public Attack_BaseClass basicAttack;
    public Attack_BaseClass strongAttack;

    public float chanceForHeavyAttack;

    public Vector2 currentHitboxTransform;
    public Attack_BaseClass currentAttack;

    [Header("Animations")]

    public string IdleAnimation;
    public string AttackAnimation;
    public string StrongAttackAnimation;
    public string DeathAnimation;
    public string WhileWalkingAnimation;

    [Header("LayerMasks")]
    public LayerMask whatIsPlayer;
    public LayerMask blockLayer;
    public LayerMask spawningPoint;

    [Header("Attack Hitboxes")]

    public GameObject attackHitbox;
    public GameObject heavyAttackHitbox;  
    
    [Header("Attack Settings")]
    public float staminaCostForAttack = 15.0f;
    public float staminaCostForHeavyAttack = 20f;
    public float lookingForPlayerradius = 30f;
    public float attackingPlayerRadius = 3f;
    public float lookingForSpawingLocationRadius = 4f;

    //choose values like 0.1,0.5 or 1
    [SerializeField] float startTimeBtwStateUpdate = 0.5f;
    public float startTimeBtwAttacks = 1f;
    public float retreatCooldown;
   
    private float timeBtwStateUpdate;    
    public float timeBtwAttacks;

    private float delayTime;
    [SerializeField] float delay;

    EnemyBaseState currentState;

    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyFollowState followState = new EnemyFollowState();
    public EnemyAttackingState attackState = new EnemyAttackingState();
    public EnemyRetreatState retreatState = new EnemyRetreatState();

    private void Start()
    {       
        statsManager = GetComponent<StatsManager>();
        agent = GetComponent<Agent>();
        enemyAnimationHandler = GetComponentInChildren<EnemyAnimationHandler>();
        currentState = idleState;
        currentState.startState(this);
    }

    private void Update()
    {        
        delayTime -= Time.deltaTime;
        timeBtwAttacks -= Time.deltaTime;
        timeBtwStateUpdate -= Time.deltaTime;
        if(timeBtwStateUpdate <= 0)
        {
            if(currentState != null)
            {
                currentState.UpdateState(this);
            }           
            timeBtwStateUpdate = startTimeBtwStateUpdate;
        }        
    }
  
    public void onDeath()
    {
        currentState = null;
        enemyAnimationHandler.playAnimation(DeathAnimation);
    }


    public void SwtichState(EnemyBaseState state)
    {
        currentState = state;
        currentState.startState(this);
    }
   
    public void setCurrentAttack(Attack_BaseClass attack)
    {
        currentAttack = attack;
    }

    public bool checkForPlayer(Vector2 worldPosition, float radius, LayerMask whatIsPlayer)
    {
        Collider2D[] playerCheck = Physics2D.OverlapCircleAll(worldPosition, radius, whatIsPlayer);
        if (playerCheck.Length > 0)
            return true;
        return false;
    }

    public bool checkForSpawningLocation(Vector2 worldPosition,float radius,LayerMask spawningPosition)
    {
        Collider2D[] playerCheck = Physics2D.OverlapCircleAll(worldPosition, radius, spawningPosition);
        if (playerCheck.Length > 0)
            return true;
        return false;
    }     
}
