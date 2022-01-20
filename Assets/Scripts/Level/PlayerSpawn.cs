using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawn : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer[] lightSprite;

    public UnityEvent onActivation;

    public bool isActive;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void activatePlayerSpawn()
    {
        if (!isActive)
        {
            FindObjectOfType<AudioManager>().play("SpawnerSound");
            isActive = true;
            anim.SetBool("isActivated", true);
            onActivation.Invoke();
        }
    }

    public void setLightsActive()
    {
        for(int i = 0;i< lightSprite.Length; i++)
        {
            lightSprite[i].enabled = true;
        }                
    }

}
