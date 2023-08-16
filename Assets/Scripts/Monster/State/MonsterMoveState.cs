using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMoveState : MonsterIState
{
    protected MonsterStateMachine stateMachine;
    public MonsterMoveState(MonsterStateMachine MonsterstateMachine)
    {
        stateMachine = MonsterstateMachine;
    }

    public void Enter()
    {
        stateMachine.monster.agent.isStopped = false;
        stateMachine.monster.animator.CrossFade("Walk", 0.1f);
        Debug.Log("M M Enter");
    }

    public void Exit()
    {
        stateMachine.monster.agent.isStopped = true;
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        float distance = Vector3.Distance(stateMachine.monster.transform.position, PlayerObject.instance.transform.position);
        if (distance <= 2f)
        {
            stateMachine.ChangeState(E_EnemyState.AttackState01);
        }
        else
        {
            stateMachine.monster.agent.destination = PlayerObject.instance.transform.position;
        }
    }
}
