using UnityEngine;

public class DestroyEntity : MonoBehaviour
{

    [SerializeField] GameObject parentGO;
    public void destroyGameObject()
    {
        Destroy(parentGO);
    }
}
