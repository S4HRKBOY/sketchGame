using UnityEngine;

public class RangeEnemySM : MonoBehaviour
{
    public Agent agent;
    public StatsManager statsManager;   
    public Animator anim;

    [Header("LayerMasks")]

    public LayerMask whatIsPlayer;
    public LayerMask spawningPoint;

    [Header("Animations")]

    public string Idle;
    public string ReadyToShot;
    public string Evade;
    public string Shot;
    public string Death;

    [Header("State Machine")]

    public GameObject ArrowSpawnObject;
    public GameObject RetreatObject;

    [Header("Attack Settings")]

    public Attack_BaseClass rangeAttack;

    RangeEnemyBaseState currentState;

    public RangeEnemyFollowState followState = new RangeEnemyFollowState();
    public RangeEnemyIdleState idleState = new RangeEnemyIdleState();
    public RangeEnemyRetreatState retreatState = new RangeEnemyRetreatState();
    public RangeEnemyShootingState shootingState = new RangeEnemyShootingState();


    public float startTimeBtwStateUpdate = 0.5f;
    public float startTimeBtwShots = 1f;
    public float startTimeBtwEvade = 10f;

    public float lookingForPlayerRadius;
    public float attackingPlayerRadius;
    public float playerTooCloseRadius;
    public float lookingForSpawingLocationRadius;

    public float staminaCostForShot = 10f;

    public float timeBtwEvade;
    public float timeBtwShots;
    public float timeBtwStateUpdate;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        statsManager = GetComponent<StatsManager>();
        agent = GetComponent<Agent>();        
        currentState = idleState;
        currentState.startState(this);
    }

    private void Update()
    {
        timeBtwStateUpdate -= Time.deltaTime;
        timeBtwShots -= Time.deltaTime;
        timeBtwEvade -= Time.deltaTime;

        if (timeBtwStateUpdate <= 0)
        {
            if(currentState != null)
            {
                currentState.updateState(this);
            }           
            timeBtwStateUpdate = startTimeBtwStateUpdate;
        }
    }

    public void onDeath()
    {
        currentState = null;
        playAnimation(Death);
    }

    public void SwtichState(RangeEnemyBaseState state)
    {
        currentState = state;
        currentState.startState(this);
    }

    public bool checkForPlayer(Vector2 worldPosition, float radius)
    {
        Collider2D[] playerCheck = Physics2D.OverlapCircleAll(worldPosition, radius, whatIsPlayer);
        if (playerCheck.Length > 0)
            return true;
        return false;
    }
   
    public bool checkForSpawningLocation(Vector2 worldPosition, float radius)
    {
        Collider2D[] playerCheck = Physics2D.OverlapCircleAll(worldPosition, radius, spawningPoint);
        if (playerCheck.Length > 0)
            return true;
        return false;
    }    
    public void playAnimation(string animation)
    {
        anim.Play(animation);
    }

}
