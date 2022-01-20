using UnityEngine;

public class Lever : MonoBehaviour
{
    public Door corrispondingDoor;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
}
