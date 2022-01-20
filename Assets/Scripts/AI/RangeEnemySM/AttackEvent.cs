using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    [SerializeField] RangeEnemySM sm;

    private void Start()
    {
        sm = GetComponentInParent<RangeEnemySM>();
    }

    public void performAttackEvent()
    {
        
        sm.rangeAttack.performAttack(sm.ArrowSpawnObject.transform.position);
    }

}
