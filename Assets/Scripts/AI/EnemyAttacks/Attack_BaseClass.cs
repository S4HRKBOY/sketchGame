using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_BaseClass : ScriptableObject
{
    public abstract void performAttack(Vector2 hitboxTransform);

}
