using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAttackManager : SingletonAutoMono<ForceAttackManager>
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//最长持续时间，一般为动画时间

    public Animator currentAnimator;

    protected float releaseTimer;//用于计算是否到达最长持续时间
    public bool isOnNeceTime;//当前是否为动画必须时间，即前摇

    public bool isOnAttackBuffer = false;//是否有攻击输入缓存
    public float attackBufferTime = 0.25f;//攻击缓存时间

    public static int attackIndex = 0;//当前攻击连招下标

    List<AttackData> attackDataList;//连招

    public const float animationFadeTime = 0.1f;//动画切换时间

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
