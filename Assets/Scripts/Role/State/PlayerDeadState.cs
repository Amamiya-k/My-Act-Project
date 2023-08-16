using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerDeadState :PlayerIState
{
    protected PlayerStateMachine stateMachine;

    public PlayerDeadState(PlayerStateMachine playerstateMachine)
    {

        stateMachine = playerstateMachine;
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwitchState);
    }
    public void Enter()
    {
        stateMachine.player.playerAnimator.CrossFade("Die", 0.1f);
        TimerMgr.GetInstance().AddTimer(E_EventC.PlayerDead, Dead, 3f);
    }
    public void Dead()
    {
        stateMachine.player.gameObject.SetActive(false);    
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
       
    }

    public void SwitchState()
    {

    }
}
