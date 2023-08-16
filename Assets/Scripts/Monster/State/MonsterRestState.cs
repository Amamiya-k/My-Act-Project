using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRestState : MonsterIState
{
    protected MonsterStateMachine stateMachine;
    public MonsterRestState(MonsterStateMachine MonsterstateMachine)
    {
        stateMachine = MonsterstateMachine;
        
    }

    public void Enter()
    {
        stateMachine.monster.agent.isStopped = false;
        stateMachine.monster.animator.CrossFade("Idle", 0.1f);
        Debug.Log("M r Enter");
        
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
        
    }

    
}
