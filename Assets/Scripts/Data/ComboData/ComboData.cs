using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewComboData",menuName ="ComboData/CreatNewComboData")]
public class ComboData : ScriptableObject
{
    public List<AttackData> attackDataList = new List<AttackData>();
}
