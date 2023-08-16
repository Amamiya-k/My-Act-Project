using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerSlideState : PlayerIState
{
    protected PlayerStateMachine stateMachine;

    public bool isOnSlide = false;

    public PlayerSlideState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
    }

    public void Enter()
    {
        Debug.Log("Slide Enter");
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwtichState);
        /*Debug.Log(stateMachine.ToString()); 
        Debug.Log(stateMachine.player.ToString());
        Debug.Log(stateMachine.player.playerAnimator.ToString());*/
        stateMachine.player.playerAnimator.CrossFade("Slide", 0.1f);
        isOnSlide = true;
        stateMachine.player.isOnSlide = true;
        TimerMgr.GetInstance().AddTimer(E_EventC.IsOnSlide, OnSwitchState, 0.35f);
        stateMachine.player.rbbody.useGravity = false;
        stateMachine.player.playerCollider.isTrigger = true;
        //stateMachine.player.controller.enabled  = false;
    }

    public void Exit()
    {
        stateMachine.player.isOnSlide = false;
        stateMachine.player.rbbody.useGravity = true;
        stateMachine.player.playerCollider.isTrigger = false;
        //stateMachine.player.controller.enabled =true;
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwtichState);

        //Debug.Log("P S Enter");
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {

    }

    public void OnSwitchState()
    {
        isOnSlide = false;
        InputManager.GetInstance().SwitchToIdleState();
    }

    public void SwtichState()
    {
        //Debug.Log(InputManager.GetInstance().playerState);
        if (isOnSlide) return;
        if (stateMachine.state == E_PlayerState.SlideState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
    }


}
