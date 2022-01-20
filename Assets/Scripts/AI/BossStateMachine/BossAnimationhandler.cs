using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAnimationhandler : MonoBehaviour
{
    [SerializeField] Animator anim;
    BossStateManager stateManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stateManager = GetComponentInParent<BossStateManager>();
    }

    public void playAnimation(string animation)
    {
        anim.Play(animation);
    }

    public void switchToEndScene()
    {
        SceneManager.LoadScene("ThankYouScene");
    }

    public void performAttackEvent()
    {       
        stateManager.currentAttack.performAttack(stateManager.currentAttackTransform);
    }
}
