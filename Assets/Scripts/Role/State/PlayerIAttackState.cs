/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIAttackState : PlayerIState
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;

    public Animator currentAnimator;
    public E_PlayerState nextState;

    protected float releaseTimer;
    protected bool isOnNeceTime;

    protected int attackIndex = 0;

    public const float animationFadeTime = 0.1f;

    protected PlayerStateMachine stateMachine;
    public PlayerIAttackState(PlayerStateMachine playerstateMachine)
    {
        stateMachine = playerstateMachine;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        if(Time.time > releaseTimer)
        {
            StopCombo();
        }
        HandleCombo();

    }

    public void HandleCombo() {
        if (isOnNeceTime)
        {
            return;
        }

        if (stateMachine.player.input.inputActions.Player.Attack1.WasPressedThisFrame())
        {
            stateMachine.ChangeState(nextState);
        }
    }

    protected void StopCombo()
    {
        attackIndex = 0;
    }



    protected void Attack()
    {
        List<AttackData> list = currentComboData.attackDataList;
        int comboIndex = attackIndex;


        
        
    }

    IEnumerator PlayCombo(AttackData attackData)
    {
        isOnNeceTime = true;
        releaseTimer = Time.time + releaseTime;

        currentAttackData = attackData;

        currentAnimator.CrossFade(attackData.animatorStateName, animationFadeTime);

        float timePass = 0f;
        while (true)
        {
            if (timePass >= attackData.releaseTime)
                break;
            timePass += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        isOnNeceTime = false;
        yield break;
    }


}
*/