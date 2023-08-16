using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackManager :SingletonAutoMono<NormalAttackManager>
{

    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//最长持续时间，一般为动画时间

    public Animator currentAnimator;

    public float releaseTimer;//用于计算是否到达最长持续时间
    public bool isOnNeceTime;//当前是否为动画必须时间，即前摇

    public static int attackIndex = 0;//当前攻击连招下标

    public List<AttackData> attackDataList;//连招

    public const float animationFadeTime = 0.1f;//动画切换时间

    public AttackRange attackRange;
    public Vector3 attackTarget = Vector3.zero;

    private void Start()
    {
        attackRange = new AttackRange();
    }

    public void Attack(ComboData currentComboData, Animator animator)
    {
        if (isOnNeceTime) return;
        isOnNeceTime = true;

        /*if (attackTarget != Vector3.zero)
        {
            Debug.Log(attackTarget);
            //stateMachine.player.transform.LookAt(attackTarget);
        }*/

        TimerMgr.GetInstance().StopTimer(E_EventC.StopCombo);

        attackDataList = currentComboData.attackDataList;
        currentAnimator = animator;
        int comboIndex = attackIndex;
        if (attackIndex >= currentComboData.attackDataList.Count - 1)
        {
            StopCombo();
        }
        else
        {
            attackIndex++;
        }
        currentAnimator.CrossFade(attackDataList[comboIndex].animatorStateName, animationFadeTime);
       

        TimerMgr.GetInstance().AddTimer(E_EventC.IsNeceTime, Nece, attackDataList[comboIndex].neceTime, false);
        TimerMgr.GetInstance().AddTimer(E_EventC.StopCombo, StopCombo, attackDataList[comboIndex].releaseTime, false);
    }

    public void StopCombo()
    {
        attackIndex = 0;
        EventCenter.GetInstance().EventTrigger(E_EventC.SwitchToIdleState);
    }

    public void Nece()
    {
        isOnNeceTime = false;
        
    } //=> 


}
