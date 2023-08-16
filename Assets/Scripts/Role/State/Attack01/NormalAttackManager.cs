using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackManager :SingletonAutoMono<NormalAttackManager>
{

    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//�����ʱ�䣬һ��Ϊ����ʱ��

    public Animator currentAnimator;

    public float releaseTimer;//���ڼ����Ƿ񵽴������ʱ��
    public bool isOnNeceTime;//��ǰ�Ƿ�Ϊ��������ʱ�䣬��ǰҡ

    public static int attackIndex = 0;//��ǰ���������±�

    public List<AttackData> attackDataList;//����

    public const float animationFadeTime = 0.1f;//�����л�ʱ��

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
