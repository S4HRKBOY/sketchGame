using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator anim;
    EnemyStateManager stateManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stateManager = GetComponentInParent<EnemyStateManager>();
    }

    public void playAnimation(string animation)
    {
        anim.Play(animation);
    }
      
    public void performAttackEvent()
    {
        Debug.Log("Animation triggered Event");
        stateManager.currentAttack.performAttack(stateManager.currentHitboxTransform);
    }


}
