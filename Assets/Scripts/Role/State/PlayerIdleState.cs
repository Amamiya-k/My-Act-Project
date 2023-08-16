using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerIState
{
    protected PlayerStateMachine stateMachine;

    public PlayerIdleState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
    }

    public void Enter()
    {
        Debug.Log("Idle Enter");
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwtichState);
        /*Debug.Log(stateMachine.ToString()); 
        Debug.Log(stateMachine.player.ToString());
        Debug.Log(stateMachine.player.playerAnimator.ToString());*/
        stateMachine.player.playerAnimator.CrossFade("Idle", 0.1f); 
    }

    public void Exit()
    {
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwtichState);

        //Debug.Log("P I Enter");
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        
    }

    public void SwtichState()
    {
        //Debug.Log(InputManager.GetInstance().playerState);
        if(stateMachine.state == E_PlayerState.IdleState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
    }


}
