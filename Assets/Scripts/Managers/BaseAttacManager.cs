using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttacManager : SingletonAutoMono<BaseAttacManager>
{
    public AttackData currentAttackData;
    public ComboData currentComboData;
    public float releaseTime;//�����ʱ�䣬һ��Ϊ����ʱ��

    public Animator currentAnimator;

    public float releaseTimer;//���ڼ����Ƿ񵽴������ʱ��
    public bool isOnNeceTime;//��ǰ�Ƿ�Ϊ��������ʱ�䣬��ǰҡ

    public bool isOnAttackBuffer = false;//�Ƿ��й������뻺��
    public float attackBufferTime = 0.25f;//��������ʱ��

    public static int attackIndex = 0;//��ǰ���������±�

    public List<AttackData> attackDataList;//����

    public const float animationFadeTime = 0.1f;//�����л�ʱ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
