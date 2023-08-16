using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KanataAttackDetecion : AttackDetection
{
    public AttackValueData attackValue;

    private bool isOnAttack = false;

    public void SwitchOnAttack()
    {
        isOnAttack = true;
    } //=> 
    public void SwitchOffAttack()
    {
        ClearDetectionTarget();
        isOnAttack = false;
    } //=> 

    private void Start()
    {
        EventCenter.GetInstance().AddEventListener(E_EventC.EnemySwitchOnAttack, SwitchOnAttack);
        EventCenter.GetInstance().AddEventListener(E_EventC.EnemySwitchOffAttack, SwitchOffAttack);
    }
    public override List<Collider> GetDetectionTarget()
    {
        return result;
    }

    public void OnTriggerStay(Collider collider)
    {
        if (!isOnAttack) return;
        
        if(!targets.Contains(collider))
        {
            targets.Add(collider);  
            //print(collider.gameObject.name);
        }
        foreach(Collider item in targets)
        {
            AgentHitBox hitBox;
            if (item.TryGetComponent(out hitBox)
                && hitBox.agent != null
                && hitBox.gameObject.tag == E_DeteTag.Player.ToString()
                 && !result.Contains(item))
            {
                result.Add(item);
                float res = Vector3.Dot(transform.forward, hitBox.gameObject.transform.forward);
                hitBox.GetComponent<AgentHitBox>().GetDamage(10, res);
                //TimerMgr.GetInstance().AddTimer(E_EventC.EnemyHitCd, ClearDetectionTarget, 0.1f);
            }
        }
    }


    

}
