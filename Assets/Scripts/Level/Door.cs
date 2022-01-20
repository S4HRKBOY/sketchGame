using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private bool unlocked;
    private SpriteRenderer sprite;
    private BoxCollider2D collider2D;

    public Animator anim;

    public UnityEvent DoorUnlocked;
    
    public void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    public void unlock()
    {
        if (!unlocked)
        {          
            unlocked = true;
            anim.SetBool("isOpened", true);          
            collider2D.enabled = false;           
        }        
    }

    public void unlockAndIncreaseCounter()
    {

        if (!unlocked)
        {
            DoorUnlocked.Invoke();
            FindObjectOfType<AudioManager>().play("DoorOpen");
            anim.SetBool("isOpened", true);
            unlocked = true;            
            collider2D.enabled = false;
        }       
    }
  
}
