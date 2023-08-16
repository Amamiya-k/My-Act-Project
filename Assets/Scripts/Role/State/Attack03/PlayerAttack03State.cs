using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using System.Threading;

public class PlayerAttack03State : PlayerIState
{
    protected PlayerStateMachine stateMachine;
    public ComboData comboData;
    public PlayerAttack03State(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
        AsyncOperationHandle<ComboData> handle = Addressables.LoadAssetAsync<ComboData>("Combo3");

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
        PlayerAttack03Mgr.GetInstance().Attack(comboData, stateMachine.player.playerAnimator);
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwtichState);
        Debug.Log("Attack3 Enter");
    }

    public void Exit()
    {
        Debug.Log("Attack3 Exit");
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchStateNow, SwtichState);
    }

    public void FixedUpdate()
    {

    }

    public void Update()
    {
        if (InputManager.GetInstance().AttackInputEastRelease() 
            && PlayerAttack03Mgr.GetInstance().currentState!=0)
        {
            PlayerAttack03Mgr.GetInstance().AttackBack();
        }

    }
    public void SwtichState()
    {
        if (InputManager.GetInstance().playerState == E_PlayerState.SlideState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
        else if (!PlayerAttack03Mgr.GetInstance().isOnNeceTime 
            && !PlayerAttack03Mgr.GetInstance().isOnForce
            && stateMachine.state == E_PlayerState.AttackState03
            && InputManager.GetInstance().playerState != E_PlayerState.HitState)
        {
            Debug.Log("Switch in A03");
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
            Debug.Log(33333333333333333);
            Debug.Log(InputManager.GetInstance().playerState);
        }
    }


}
