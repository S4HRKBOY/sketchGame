using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
      
    public PlayerInputSO _playerInput;
    public UpgradeTest _upgradeTest;
    public GameObject blockCollider;
    public GameObject attackCollider;

    [SerializeField] GameObject ArrowSpawnObject;    
    [SerializeField] Transform spriteTransform;

    public LayerMask UpgradeArea;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsObstacle;

    [SerializeField] float speed;
    [SerializeField] float startTimeBtwEvade = 1f;
    [SerializeField] float evadeDistance;
    [SerializeField] float evadeStaminaCost;

    private float timeBtwEvade;
    private Rigidbody2D _rb2d;
    private Vector2 direction;
    private StatsManager manager;

    private void OnEnable()
    {
        _playerInput.OpenMenu += openMenu;
        _playerInput.PlayerMovement += calculateMovementValues;
        _playerInput.Evade += evade;
    }

    private void OnDisable()
    {
        _playerInput.OpenMenu -= openMenu;
        _playerInput.PlayerMovement -= calculateMovementValues;
        _playerInput.Evade -= evade;
    }

    private void Start()
    {
        manager = GetComponent<StatsManager>();
        _rb2d = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        timeBtwEvade -= Time.deltaTime;
    }

    private void FixedUpdate()
    {        
        updateColliderPosition();
        playerMove();
    }
    
    private void evade()
    {
        if (_upgradeTest.upgradeList[2] && timeBtwEvade <= 0 && manager.stamina >= evadeStaminaCost)
        {
            Vector2 evadeDirection = direction.normalized;

            float newDestinationX = transform.position.x + evadeDirection.x * evadeDistance;
            float newDestinationY = transform.position.y + evadeDirection.y * evadeDistance;

            Collider2D[] checkForObstacles = Physics2D.OverlapCircleAll(new Vector2(newDestinationX, newDestinationY), 3f, whatIsObstacle);

            if(checkForObstacles.Length > 0)
            {
                Debug.Log("Obstacle in the Way!");
                return;
            }
            transform.position = new Vector3(newDestinationX, newDestinationY, 0);
            timeBtwEvade = startTimeBtwEvade;
        }
    }

    private void openMenu()
    {
        if (!PauseMenu.GameIsPaused)
        {
            FindObjectOfType<PauseMenu>().pause();
        }
    }

    private void calculateMovementValues(Vector2 value)
    {

        if(value != direction)
        {
            direction = value;
            rotateCharacterSprite(direction);
        }       
    }

    private void rotateCharacterSprite(Vector2 value)
    {       
        if (value.x > 0 && value.y > 0)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 45);
            return;
        }
        if (value.x < 0 && value.y > 0)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 135);
            return;
        }
        if (value.x < 0 && value.y < 0)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 225);
            return;
        }
        if (value.x > 0 && value.y < 0)
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 315);
            return;
        }        
        if (value == new Vector2(1, 0))
        {
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 0);            
            return;
        }        
        if(value == new Vector2(0, 1))
        {           
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 90);
            return;
        }         
        if(value == new Vector2(-1, 0))
        {
            
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 180);
            return;
        }       
        if(value == new Vector2(0, -1))
        {
            
            spriteTransform.localRotation = Quaternion.Euler(0, 0, 270);
            return;
        }        
    }

    private void updateColliderPosition()
    {
        Vector2 currentPosition = direction * 1.5f;        
        if(direction != new Vector2(0, 0))
        {            
            attackCollider.transform.localPosition = direction * 1.5f;
            ArrowSpawnObject.transform.localPosition = direction * 1.5f;
        }
        
    }

    private void playerMove()
    {
        _rb2d.MovePosition(_rb2d.position + direction * speed * Time.fixedDeltaTime);
    }   
           
}
