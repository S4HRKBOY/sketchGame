using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="DoorsContainer")]
public class DoorsContainer : ScriptableObject {

    public int DoorsCounterSO = 0;

    public void setNewDoorsCounterSO(int value)
    {
        DoorsCounterSO = value;
    }

}
