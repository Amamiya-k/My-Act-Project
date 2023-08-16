using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerAttackRestState : PlayerIState
{
    protected PlayerStateMachine stateMachine;

    public PlayerAttackRestState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        /*if (AttackInput())
        {
            stateMachine.ChangeState(E_PlayerState.AttackState01);
        }*/
    }

    /*public bool AttackInput()
    {
        //bool attackInput = stateMachine.player.input.inputActions.Player.AttackWest.WasPressedThisFrame();
        //return attackInput;
    }*/
}
