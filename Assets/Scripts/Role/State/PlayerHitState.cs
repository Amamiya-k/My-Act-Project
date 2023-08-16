using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerIState
{
    protected PlayerStateMachine stateMachine;
    public bool isOnHit = false;

    public PlayerHitState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
        
    }
    public void Enter()
    {
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwitchState);
        isOnHit = true;
        stateMachine.player.playerAnimator.CrossFade("Hit", 0.1f);
        TimerMgr.GetInstance().AddTimer(E_EventC.IsOnHit, SwitchOnHit, 0.3f);
        Debug.Log("Hit Enter");
    }

    public void SwitchOnHit()
    {
        isOnHit = false;
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchToIdleState);
        //EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
    } 

    public void Exit()
    {
        Debug.Log("Hit Exit");
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwitchState);
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {

    }

    public void SwitchState()
    {
        if (isOnHit) return;
        if (stateMachine.state == E_PlayerState.HitState)
        {
            Debug.Log("Switch in Hit");
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
        
    }
}
