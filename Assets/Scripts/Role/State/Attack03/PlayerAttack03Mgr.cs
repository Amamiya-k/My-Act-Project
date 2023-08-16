using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack03Mgr : SingletonAutoMono<PlayerAttack03Mgr>
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTimer;//最长持续时间计时器，一般为动画时间

    public Animator currentAnimator;

    public float stateTimer1 = 1.7f;
    public float stateTimer2 = 3.7f;

    public bool isOnNeceTime;//当前是否为动画必须时间，即前摇

    public static int attackIndex = 0;//当前攻击连招下标

    public List<AttackData> attackDataList;//连招

    public const float animationFadeTime = 0.1f;//动画切换时间

    public float pressTime = 0;//当前按下时间

    public int currentState = 0;

    public bool isOnForce { get; private set; }

    public void CurrentState1() => currentState = 2;
    public void CurrentState2() => currentState = 3;    
    public void Attack(ComboData currentComboData, Animator animator)
    {
        isOnForce = true;
        TimerMgr.GetInstance().AddTimer(E_EventC.CurrentState1, CurrentState1, 1.7f, false);
        TimerMgr.GetInstance().AddTimer(E_EventC.CurrentState2, CurrentState2, 3.7f, false);
        TimerMgr.GetInstance().StopTimer(E_EventC.IsRelease);
        currentState = 1;
        if (isOnNeceTime)
        {
            return;
        }
        attackDataList = currentComboData.attackDataList;
        currentAnimator = animator;


        currentAnimator.CrossFade(attackDataList[0].animatorStateName, animationFadeTime);
        isOnNeceTime = true;
        TimerMgr.GetInstance().AddTimer(E_EventC.IsRelease, AttackBack, attackDataList[0].releaseTime, false);
        TimerMgr.GetInstance().AddTimer(E_EventC.IsNeceTime, Nece, attackDataList[0].neceTime, false);
    }

    public void Nece() => isOnNeceTime = false;

    public void AttackBack()
    {
        TimerMgr.GetInstance().StopTimer(E_EventC.IsNeceTime);
        isOnNeceTime = true;
        isOnForce = false;
        TimerMgr.GetInstance().AddTimer(E_EventC.AttackEnd, Nece, attackDataList[1].neceTime, false);
        TimerMgr.GetInstance().AddTimer(E_EventC.AttackEnd, AttackEnd, attackDataList[1].releaseTime, false);
        currentAnimator.CrossFade(attackDataList[1].animatorStateName, animationFadeTime);
        //TimerMgr.GetInstance().AddTimer(E_EventC.AttackEnd, AttackEnd, attackDataList[1].releaseTime, false);

        if (currentState == 1)
        {
            print(1);
        }
        else if (currentState == 2)
        {
            print(2);
        }
        else if (currentState == 3)
        {
            print(3);
        }
        currentState = 0;
        //EventCenter.GetInstance().EventTrigger("SwitchToIdleState");
    }

    public void AttackEnd()
    {
        isOnNeceTime = false;
        isOnForce = false;
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchToIdleState);
        print(isOnForce);
        print(InputManager.GetInstance().playerState);
    }

}
