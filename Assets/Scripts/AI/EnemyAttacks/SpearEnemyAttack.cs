using UnityEngine;

[CreateAssetMenu(menuName ="EnemyAttacks/BasicCircularAttack")]
public class SpearEnemyAttack : Attack_BaseClass
{
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] LayerMask blockingMask;    
    [SerializeField] int attackDamage;
    [SerializeField] float attackRadius;
    
    public override void performAttack(Vector2 hitboxTransform)
    {
        FindObjectOfType<AudioManager>().play("EnemyAttack");       
        Collider2D[] checkForPlayer = Physics2D.OverlapCircleAll(hitboxTransform, attackRadius, whatIsPlayer);
        if(checkForPlayer.Length > 0)
        {
            Collider2D[] checkForBlocking = Physics2D.OverlapCircleAll(hitboxTransform, attackRadius, blockingMask);

            if(checkForBlocking.Length > 0)
            {
                FindObjectOfType<AudioManager>().play("Block");               
                return;
            }
            else
            {
                FindObjectOfType<AudioManager>().play("HitEnemy");
            }
            checkForPlayer[0].GetComponent<StatsManager>().takeDamage(attackDamage);            
            
        }        
    }  
}
