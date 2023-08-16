using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack01Mgr : MonoBehaviour
{
    private bool _isOnNece = false;
    public bool isOnNece => _isOnNece;
    public void SetNece() => _isOnNece = false;
    public void AttackStart(AttackData attackData)
    {
        TimerMgr.GetInstance().AddTimer(E_EventC.AttackStart, SetNece, attackData.neceTime, false);
    }
}
