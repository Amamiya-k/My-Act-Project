using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using System.Threading;

public class PlayerAttack02State : PlayerIState
{
    protected PlayerStateMachine stateMachine;
    public ComboData comboData;
    private bool isOnForce = false;
    private Vector3 moveDir;
    private Vector2 moveInput;
    public PlayerAttack02State(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
        AsyncOperationHandle<ComboData> handle = Addressables.LoadAssetAsync<ComboData>("Combo2");

        handle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                comboData = handle.Result;
            }
        };
    }

    public void Enter()
    {
        PlayerAttack02Mgr.GetInstance().Attack(comboData, stateMachine.player.playerAnimator);
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwtichState);
        Debug.Log("Attack2 Enter");
        isOnForce = true;
    }

    public void Exit()
    {
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwtichState);
    }

    public void FixedUpdate()
    {
        moveInput = InputManager.GetInstance().MoveInput();
        if (moveInput != Vector2.zero && !PlayerAttack02Mgr.GetInstance().isOnNeceTime)
        {
            Move();
        }
    }

    public void Update()
    {
        
        if (InputManager.GetInstance().AttackInputNorthRelease())
        {
            //Rotate();
            PlayerAttack02Mgr.GetInstance().AttackBack();
            isOnForce = false;
        }
        

    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        if (moveDir == Vector3.zero) return;
        Rotate();
        //stateMachine.player.controller.Move(moveDir * Time.deltaTime * 5);
        //stateMachine.player.rbbody.velocity = moveDir *5;
        stateMachine.player.rbbody.AddForce(moveDir * 5, ForceMode.VelocityChange);
    }

    private void Rotate()
    {
        RotateDirection();
        stateMachine.player.transform.rotation = Quaternion.LookRotation(moveDir);
    }

    private void RotateDirection()
    {
        float y = stateMachine.player.mainCameraTransform.eulerAngles.y;
        moveDir = Quaternion.Euler(0, y, 0) * moveDir;
    }

    public void SwtichState()
    {
        if (InputManager.GetInstance().playerState == E_PlayerState.SlideState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
        else if (!PlayerAttack02Mgr.GetInstance().isOnNeceTime
            && !isOnForce
            && stateMachine.state == E_PlayerState.AttackState02
            && InputManager.GetInstance().playerState != E_PlayerState.MoveState) 
        {
            Debug.Log(isOnForce);
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
    }


}
