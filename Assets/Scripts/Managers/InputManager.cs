using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class InputManager : SingletonAutoMono<InputManager>
{
    public PlayerInputAction inputAction { get; private set; }
    public E_PlayerState playerState;
    public E_PlayerState attackBuffer = E_PlayerState.IdleState;

    private bool isOnAttackBuffer = false;
    public float attackBufferTime = 0.15f;//¹¥»÷»º´æÊ±¼ä

    // Start is called before the first frame update
    void Start()
    {
        inputAction = PlayerObject.instance.inputAction;
        EventCenter.GetInstance().AddEventListener(E_EventC.SwitchToIdleState,SwitchToIdleState);

        inputAction.Player.Load.performed += (callback) =>
        {
            
                Addressables.LoadAssetAsync<GameObject>("Monster").Completed += (handle) =>
                {
                    if (handle.Status == AsyncOperationStatus.Succeeded)
                    {
                        GameObject obj = Instantiate(handle.Result);

                        obj.name = name;
                    }
                };
            
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (SlideInputSouth()) { }
        else if (AttackInputEast()) { }
        else if (AttackInputWest()) { }
        else if (AttackInputNorth()) { }
        else if (isOnAttackBuffer)
        {
            playerState = attackBuffer;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
        }
        else if (playerState != E_PlayerState.MoveState && MoveInput() != Vector2.zero) 
        {
            playerState = E_PlayerState.MoveState;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
        }
        /*else if (playerState!=E_PlayerState.IdleState && MoveInput() == Vector2.zero)
        {
            playerState = E_PlayerState.IdleState;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
        }*/
    }



    public void SwitchToIdleState()
    {
        playerState = E_PlayerState.IdleState;
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
    }

    public E_PlayerState InputCase()
    {
        return playerState;
    }

    public Vector2 MoveInput()
    {
        Vector2 moveInput = inputAction.Player.Move.ReadValue<Vector2>();
        return moveInput;
    }

    public bool AttackInputWest()
    {
        bool attackInput = inputAction.Player.AttackWest.WasPressedThisFrame();
        if (attackInput)
        {
            TimerMgr.GetInstance().StopTimer(E_EventC.AttackBuffer);
            attackBuffer = E_PlayerState.AttackState01;
            playerState = attackBuffer;
            isOnAttackBuffer = true;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
            TimerMgr.GetInstance().AddTimer(E_EventC.AttackBuffer, InputBuffer, attackBufferTime, false);
        }
        return attackInput;
    }

    public bool AttackInputNorth()
    {
        bool attackInput = inputAction.Player.AttackNorth.WasPressedThisFrame();
        if (attackInput)
        {
            TimerMgr.GetInstance().StopTimer(E_EventC.AttackBuffer);
            attackBuffer = E_PlayerState.AttackState02;
            playerState = attackBuffer;
            isOnAttackBuffer = true;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
            TimerMgr.GetInstance().AddTimer(E_EventC.AttackBuffer, InputBuffer, attackBufferTime, false);
        }
        return attackInput;
    }

    public bool AttackInputEast()
    {
        bool attackInput = inputAction.Player.AttackEast.WasPressedThisFrame();
        if (attackInput)
        {
            TimerMgr.GetInstance().StopTimer(E_EventC.AttackBuffer);
            attackBuffer = E_PlayerState.AttackState03;
            playerState = attackBuffer;
            isOnAttackBuffer = true;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
            TimerMgr.GetInstance().AddTimer(E_EventC.AttackBuffer, InputBuffer, attackBufferTime, false);
        }
        return attackInput;
    }

    public bool SlideInputSouth()
    {
        bool Input = inputAction.Player.AttackSouth.WasPressedThisFrame();
        if (Input)
        {
            playerState = E_PlayerState.SlideState;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
        }
        return Input;
    }

    private void InputBuffer()
    {
        isOnAttackBuffer = false;
    } 

    public bool AttackInputEastPress()
    {
        bool attackInput = inputAction.Player.AttackEast.IsPressed();
        return attackInput;
    }

    public bool AttackInputEastRelease()
    {
        bool attackInput = inputAction.Player.AttackEast.WasReleasedThisFrame();
        return attackInput;
    }

    public bool AttackInputNorthRelease()
    {
        bool attackInput = inputAction.Player.AttackNorth.WasReleasedThisFrame();
        return attackInput;
    }
    private void OnEnable()
    {
        EventCenter.GetInstance().RemoveEventListener(E_EventC.SwitchToIdleState,SwitchToIdleState);
    }

    

}
