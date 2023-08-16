using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_EnemyState
{
    IdleState,
    MoveState,
    AttackState01,
    DeadState
}

public class MonsterStateMachine
{
    protected E_EnemyState currentState;
    public MonsterObject monster;
    public Dictionary<E_EnemyState, MonsterIState> stateDic = new Dictionary<E_EnemyState, MonsterIState>();

    public void Init(MonsterObject newMonster)
    {
        stateDic.Add(E_EnemyState.IdleState,new MonsterIdleState(this));
        stateDic.Add(E_EnemyState.MoveState, new MonsterMoveState(this));
        stateDic.Add(E_EnemyState.AttackState01, new MonsterAttack01State(this));
        stateDic.Add(E_EnemyState.DeadState, new MonsterDeadState(this));
        currentState = E_EnemyState.IdleState;
        monster = newMonster;
    }

    public void ChangeState(E_EnemyState newState)
    {
        stateDic[currentState]?.Exit();

        currentState = newState;

        stateDic[currentState].Enter();
    }

    public virtual void Update()
    {
        stateDic[currentState].Update();
    }
}
