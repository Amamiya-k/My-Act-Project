using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttacManager : SingletonAutoMono<BaseAttacManager>
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//最长持续时间，一般为动画时间

    public Animator currentAnimator;

    public float releaseTimer;//用于计算是否到达最长持续时间
    public bool isOnNeceTime;//当前是否为动画必须时间，即前摇

    public bool isOnAttackBuffer = false;//是否有攻击输入缓存
    public float attackBufferTime = 0.25f;//攻击缓存时间

    public static int attackIndex = 0;//当前攻击连招下标

    public List<AttackData> attackDataList;//连招

    public const float animationFadeTime = 0.1f;//动画切换时间

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
