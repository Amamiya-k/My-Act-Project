using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack01State : MonsterIState
{
    protected MonsterStateMachine stateMachine;
    public MonsterAttack01State(MonsterStateMachine MonsterstateMachine)
    {
        stateMachine = MonsterstateMachine;
    }

    public void Enter()
    {
        Debug.Log("M M Enter");
        stateMachine.monster.animator.CrossFade("Attack01", 0.2f);
        stateMachine.monster.transform.LookAt(PlayerObject.instance.transform.position);
        //EventCenter.GetInstance().AddEventListener("MonsterRest", Change);
        MonsterManager.GetInstance().StartRest();
        EventCenter.GetInstance().AddEventListener(E_EventC.MonsterRest, SwitchToIdle);
    }

    public void Change()
    {
        stateMachine.ChangeState(E_EnemyState.IdleState);
    }

    public void Exit()
    {
        EventCenter.GetInstance().RemoveEventListener(E_EventC.MonsterRest, SwitchToIdle);
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        float distance = Vector3.Distance(stateMachine.monster.transform.position, PlayerObject.instance.transform.position);
        if (distance >= 2f)
        {
            stateMachine.ChangeState(E_EnemyState.MoveState);
        }
    }

    public void SwitchToIdle()
    {
        stateMachine.ChangeState(E_EnemyState.IdleState);
    }
}
