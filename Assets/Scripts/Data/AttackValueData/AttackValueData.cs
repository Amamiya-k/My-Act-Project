using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Attribute
{
    Fire,
    ice,
}

[CreateAssetMenu(fileName ="NewAttackValueData",menuName ="AttackValueData/CreatNewAttackValueData")]
public class AttackValueData : ScriptableObject
{
    public E_Attribute attribute;
    public float toughnessDmg;
    public float damageMult;
}
