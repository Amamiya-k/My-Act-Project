using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventMgr : MonoBehaviour
{
    public void EnemyAttackOn()
    {
        EventCenter.GetInstance().EventTrigger(E_EventC.EnemySwitchOnAttack);
    }

    public void EnemyAttackOff()
    {
        EventCenter.GetInstance().EventTrigger(E_EventC.EnemySwitchOffAttack);
    }
}
