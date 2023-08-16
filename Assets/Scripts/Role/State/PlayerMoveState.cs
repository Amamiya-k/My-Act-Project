using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerIState
{
    protected PlayerStateMachine stateMachine;

    public Vector3 moveDir;
    public Vector2 moveInput;
    public PlayerMoveState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
        
    }

    public void Enter()
    {
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwtichState);
        Debug.Log("MoveEnter");
        stateMachine.player.playerAnimator.CrossFade("Runnoroot", 0.1f);
    }

    public void Exit()
    {
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwtichState);
    }

    public void FixedUpdate()
    {
        moveInput = InputManager.GetInstance().MoveInput();
        Move();
    }

    public void Update()
    {
        
        if (moveInput == Vector2.zero)
        {
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchToIdleState);
        }
        
        //Rotate();
    }

    public void SwtichState()
    {
        if(stateMachine.state==E_PlayerState.MoveState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
            //Debug.Log(InputManager.GetInstance().playerState);
        }
    }

    private void RotateDirection()
    {
        float y = stateMachine.player.mainCameraTransform.eulerAngles.y;
        moveDir = Quaternion.Euler(0, y, 0) * moveDir;
    }

    private void Move() 
    {
        moveDir = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        if(moveDir == Vector3.zero) return;
        Rotate();
        //stateMachine.player.controller.Move(moveDir * Time.deltaTime * 5);//
        //stateMachine.player.rbbody.velocity = Vector3.forward;
        stateMachine.player.rbbody.AddForce(moveDir * 5, ForceMode.VelocityChange);
    }

    private void Rotate()
    {
        RotateDirection();
        stateMachine.player.transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
