using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_DeteTag
{
    Monster,
    Player,

}

public enum E_AEvent
{
    SwitchOnAttack,
    SwitchOffAttack
}

public enum E_EventC
{
    SwitchOnAttack,
    SwitchOffAttack,
    EnemySwitchOnAttack,
    EnemySwitchOffAttack,
    AttackBuffer,
    AttackStart,
    AttackEnd,
    StopCombo,
    IsNeceTime,
    IsRelease,
    CurrentState1,
    CurrentState2,
    SwitchToIdleState,
    SwitchStateNow,
    LoadCharacter,
    MonsterRest,
    MonsterDead,
    PlayerDead,
    IsOnHit,
    IsOnSlide,
    EnemyHitCd,
    EnemyRegister,
}
public class EnumAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
