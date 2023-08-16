using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeadState : MonsterIState
{
    protected MonsterStateMachine stateMachine;
    public MonsterDeadState(MonsterStateMachine MonsterstateMachine)
    {
        stateMachine = MonsterstateMachine;
    }
    public void Enter()
    {
        stateMachine.monster.animator.CrossFade("Die", 0.1f);
        TimerMgr.GetInstance().AddTimer(E_EventC.MonsterDead, Dead, 3f, false);
    }

    public void Dead()
    {
        stateMachine.monster.gameObject.SetActive(false);    
    }

    

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
