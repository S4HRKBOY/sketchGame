using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;



public class StatsManager : MonoBehaviour
{
    public float maxStamina = 50;
    public int maxHealth = 100;    
    public int health = 100;
    public float stamina = 50;
    public float staminaRegenerationRate;

    public UnityEvent deathEvent;
    
    private Animator anim;
    [SerializeField] string deathAnimation;
    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public float getStamina()
    {
        return stamina;
    }

    private void Update()
    {
        regenerateStamina();
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " " + this.gameObject.ToString());
        if(health <= 0)
        {           
            health = 0;            
            entityDeath();
        }
    }
    private void regenerateStamina()
    {
        if(stamina >= 50)
        {
            stamina = 50;
            return;
        }
        stamina += staminaRegenerationRate;
    }
    public void reduceStamina(float staminaDamage)
    {
        stamina -= staminaDamage;

        if(stamina < 0)
        {
            stamina = 0;
        }

    }
    public void entityDeath()
    {
        deathEvent.Invoke();
        if(gameObject.tag == "Player")
        {           
            SceneManager.LoadScene(1);
            return;
        }       
    }
}
