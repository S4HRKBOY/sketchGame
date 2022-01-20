using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] bool hasHitSomething;

    Animator anim;

    [SerializeField] bool isFromBoss;
    [SerializeField] float arrowLifeTime = 5f;
    [SerializeField] LayerMask shooterMask;
    [SerializeField] LayerMask targetMask;

    [SerializeField] float lookingForShooterRadius = 2f;
    [SerializeField] float damagingRadius = 1f;

    [SerializeField] float speed = 0.05f;
    [SerializeField] int damage = 10;

    public string ArrowAnimation;
    public string ArrowDeathAnimation;

    Vector2 shooterPosition;
    Vector2 direction;

    private void Awake()
    {        
        shooterPosition = lookForShooter();
        Debug.Log(shooterPosition);
        if(shooterPosition == Vector2.zero)
        {            
            destroyArrow();
        }
        setAngle();
        Vector2 gapBtwShooter = new Vector2(transform.position.x,transform.position.y) - shooterPosition;
        direction = gapBtwShooter.normalized;
        anim = GetComponent<Animator>();

        if(ArrowAnimation != null)
            anim.Play(ArrowAnimation);
    }
  
    // Update is called once per frame
    void Update()
    {
        arrowLifeTime -= Time.deltaTime;

        if (arrowLifeTime <= 0)
            Destroy(gameObject);

        if (!hasHitSomething)
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed;
        }
        
    }

    private Vector2 lookForShooter()
    {
        Collider2D[] lookingForShooter = Physics2D.OverlapCircleAll(transform.position, lookingForShooterRadius, shooterMask);
        Debug.Log(lookingForShooter.Length);
        if(lookingForShooter.Length > 0)
        {
            return lookingForShooter[0].transform.position;
        }
        return Vector2.zero;
    }
  
    private void setAngle()
    {
        var spawnPosition = transform.position;
        var shooterPosition = this.shooterPosition;

        float x = spawnPosition.x - shooterPosition.x;
        float y = spawnPosition.y - shooterPosition.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ArrowCollision");
        Debug.Log(collision.gameObject.layer.ToString());
        if(collision.gameObject.layer == shooterMask)
        {
            return;
        }

        // 11 = EnemySpawnPositions
        if (collision.gameObject.layer == 11)
        {
            return;
        }   
        
        if(collision.gameObject.layer == 15)
        {
            return;
        }
      
        hasHitSomething = true;
        anim.Play(ArrowDeathAnimation);
        if (!isFromBoss)
        {
            FindObjectOfType<AudioManager>().play("ArrowHit");
        }
               
        Collider2D[] lookingForPlayer = Physics2D.OverlapCircleAll(transform.position, damagingRadius, targetMask);
        for (int i = 0; i < lookingForPlayer.Length; i++)
        {
           lookingForPlayer[i].GetComponent<StatsManager>().takeDamage(damage);
           Debug.Log(damage);
        }
        

        if (collision.gameObject.layer == 12)
        {
            Debug.Log("ButtonHit");
            Lever lever = collision.GetComponent<Lever>();
            lever.corrispondingDoor.unlockAndIncreaseCounter();
            lever.GetComponent<Lever>().anim.SetBool("IsSwitched", true);
            destroyArrow();
        }

        if(collision.gameObject.layer == 8)
        {
            Debug.Log("Hitted Unwalkable");
        }

        //PlayerBlocking
        if (collision.gameObject.layer == 10)
        {
            FindObjectOfType<AudioManager>().play("Block");
            return;
        }
            
                              
    }

    public void destroyArrow()
    {
        Destroy(gameObject);
    }

}
