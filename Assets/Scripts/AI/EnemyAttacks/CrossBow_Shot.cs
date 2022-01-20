using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAttacks/CrossBowAttack")]
public class CrossBow_Shot : Attack_BaseClass
{

    [SerializeField] GameObject Arrow;
    [SerializeField] bool isFromBoss;

    public override void performAttack(Vector2 ArrowSpawnPosition)
    {
        if (!isFromBoss)
        {
            FindObjectOfType<AudioManager>().play("ArrowShot");
        }       
        Instantiate(Arrow, ArrowSpawnPosition, Quaternion.identity);
    }
}
