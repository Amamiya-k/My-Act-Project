using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting.FullSerializer;

public class PlayerAttack01State : PlayerIState
{
    protected PlayerStateMachine stateMachine;
    public ComboData comboData;
    public Vector3 attackTarget = Vector3.zero;

    public PlayerAttack01State(PlayerStateMachine playerstateMachine)
    {
         
        stateMachine = playerstateMachine;
        AsyncOperationHandle<ComboData> handle = Addressables.LoadAssetAsync<ComboData>("NormalCombo1");

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
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwitchState);
        attackTarget = AttackRange.instance.GetAttackTarget(stateMachine.player.transform.position);
        if (attackTarget != Vector3.zero)
        {
            Debug.Log(attackTarget);
            stateMachine.player.transform.LookAt(attackTarget);
        }
        NormalAttackManager.GetInstance().Attack(comboData, stateMachine.player.playerAnimator);
        
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchStateNow, SwitchState);
        Debug.Log("A01Enter");
    }

    public void Exit()
    {

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
        if(InputManager.GetInstance().playerState == E_PlayerState.SlideState)
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
        else if (!NormalAttackManager.GetInstance().isOnNeceTime
            && stateMachine.state == E_PlayerState.AttackState01) 
        {
            stateMachine.ChangeState(InputManager.GetInstance().playerState);
        }
    }


    
}
