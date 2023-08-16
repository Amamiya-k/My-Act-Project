using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public enum E_PlayerState
{
    IdleState,
    MoveState,
    AttackState01,
    AttackState02,
    AttackState03,
    AttackState04,
    DeadState,
    HitState,
    SlideState,
}

public class PlayerStateMachine
{
    protected E_PlayerState currentState;
    public E_PlayerState state => currentState;

    public PlayerObject player;
    public Dictionary<E_PlayerState, PlayerIState> stateDic = new Dictionary<E_PlayerState, PlayerIState>();
    public bool attackInput;
    public void Init(PlayerObject newPlayer)
    {
        player = newPlayer;
        stateDic.Add(E_PlayerState.IdleState, new PlayerIdleState(this));
        stateDic.Add(E_PlayerState.MoveState, new PlayerMoveState(this));
        stateDic.Add(E_PlayerState.AttackState01, new PlayerAttack01State(this));
        stateDic.Add(E_PlayerState.AttackState02, new PlayerAttack02State(this));
        stateDic.Add(E_PlayerState.AttackState03, new PlayerAttack03State(this));
        stateDic.Add(E_PlayerState.DeadState, new PlayerDeadState(this));
        stateDic.Add(E_PlayerState.HitState, new PlayerHitState(this)); 
        stateDic.Add(E_PlayerState.SlideState, new PlayerSlideState(this));
        ChangeState(E_PlayerState.IdleState);
        //currentState = E_PlayerState.IdleState;
        
    }

    public void ChangeState(E_PlayerState newState)
    {
        stateDic[currentState]?.Exit();

        currentState = newState;

        stateDic[currentState].Enter();

    }

    public virtual void Update()
    {
        stateDic[currentState].FixedUpdate();
        stateDic[currentState].Update();
    }

}
