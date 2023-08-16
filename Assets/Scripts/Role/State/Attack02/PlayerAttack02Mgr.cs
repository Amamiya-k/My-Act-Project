using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack02Mgr : SingletonAutoMono<PlayerAttack02Mgr>
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

    // Start is called before the first frame update
    public void Attack(ComboData currentComboData, Animator animator)
    {
        TimerMgr.GetInstance().StopTimer(E_EventC.IsRelease);
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
        TimerMgr.GetInstance().AddTimer(E_EventC.AttackEnd, AttackEnd, attackDataList[1].neceTime, false);
        currentAnimator.CrossFade(attackDataList[1].animatorStateName, animationFadeTime);
        //TimerMgr.GetInstance().AddTimer(E_EventC.AttackEnd, AttackEnd, attackDataList[1].releaseTime, false);

        currentState = 0;
        //EventCenter.GetInstance().EventTrigger("SwitchToIdleState");
    }

    public void AttackEnd()
    {
        isOnNeceTime = false;
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchToIdleState);
    }

}
