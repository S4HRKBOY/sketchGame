using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    Animator animator;
    PlayerAttackManager manager;

    void Start()
    {
        manager = GetComponentInParent<PlayerAttackManager>();
        animator = GetComponent<Animator>();
    }

    public void changeAnimationState(string newState)
    {       
        animator.Play(newState);              
    }

    public void strongAttackFunction()
    {
        FindObjectOfType<AudioManager>().play("StrongAttack");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(manager.attackCollider.transform.position, manager.attackRadius, manager.whatIsEnemy);
        if(enemiesToDamage.Length > 0)
        {
            FindObjectOfType<AudioManager>().play("SwordHitPlayer");
        }
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<StatsManager>().takeDamage(manager.strongAttackDamage);
        }
    }

}
