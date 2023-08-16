using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventMgr : MonoBehaviour
{
    public void AttackOn()
    {
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchOnAttack);
    }

    public void AttackOff()
    {
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchOffAttack);
    }

    public void EnemyAttackOn()
    {

    }
}
