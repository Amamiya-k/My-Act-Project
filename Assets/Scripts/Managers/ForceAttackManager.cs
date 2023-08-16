using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAttackManager : SingletonAutoMono<ForceAttackManager>
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//�����ʱ�䣬һ��Ϊ����ʱ��

    public Animator currentAnimator;

    protected float releaseTimer;//���ڼ����Ƿ񵽴������ʱ��
    public bool isOnNeceTime;//��ǰ�Ƿ�Ϊ��������ʱ�䣬��ǰҡ

    public bool isOnAttackBuffer = false;//�Ƿ��й������뻺��
    public float attackBufferTime = 0.25f;//��������ʱ��

    public static int attackIndex = 0;//��ǰ���������±�

    List<AttackData> attackDataList;//����

    public const float animationFadeTime = 0.1f;//�����л�ʱ��

    public void Update()
    {
        if (Time.time > releaseTimer)
        {
            StopCombo();
        }
    }

    public void StopCombo()
    {
        attackIndex = 0;
    }

    public bool OnAttackBuffer()
    {
        return isOnAttackBuffer;
    }

    public void AttackInputBuffer()
    {
        StopCoroutine("AttackBuffer");
        isOnAttackBuffer = true;
        StartCoroutine("AttackBuffer");
    }

    IEnumerator AttackBuffer()
    {
        float time = 0;
        /*if( time<=0 )
        {
            isOnAttackBuffer = false;
        }*/

        while (true)
        {
            if (time >= attackBufferTime)
            {
                break;
            }
            
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isOnAttackBuffer = false;
        yield break;
    }

    public void Attack(ComboData currentComboData, Animator animator)
    {
        if (isOnNeceTime)
        {
            return;
        }
        attackDataList = currentComboData.attackDataList;
        currentAnimator = animator;
        int comboIndex = attackIndex;
        if (attackIndex >= currentComboData.attackDataList.Count - 1)
        {
            StopCombo();
        }
        else attackIndex++;
        StartCoroutine(PlayCombo(attackDataList[comboIndex]));
    }

    IEnumerator PlayCombo(AttackData attackData)
    {
        
        isOnNeceTime = true;
        releaseTimer = Time.time + attackData.releaseTime;

        currentAttackData = attackData;

        currentAnimator.CrossFade(attackData.animatorStateName, animationFadeTime);

        float timePass = 0f;
        while (true)
        {
            if (timePass >= attackData.neceTime)
                break;
            timePass += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        isOnNeceTime = false;
        yield break;
    }


    

}
