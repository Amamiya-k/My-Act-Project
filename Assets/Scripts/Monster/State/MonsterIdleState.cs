using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterIState
{
    protected MonsterStateMachine stateMachine;
    public MonsterIdleState(MonsterStateMachine MonsterstateMachine)
    {
        stateMachine = MonsterstateMachine;
    }

    public void Enter()
    {
        Debug.Log("M I Enter");
        stateMachine.monster.animator.CrossFade("Idle", 0.1f);
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        if (FoundPlayer())
        {
            stateMachine.ChangeState(E_EnemyState.MoveState);
        }
    }

    public bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(stateMachine.monster.transform.position, 10f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

}
