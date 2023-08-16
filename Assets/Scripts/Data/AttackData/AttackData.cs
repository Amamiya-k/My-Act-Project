using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewAttackData",menuName ="AttackData/CreatNewAttackData")]
public class AttackData : ScriptableObject
{
    public string animatorStateName;
    public float neceTime;
    public float releaseTime;
    
}
