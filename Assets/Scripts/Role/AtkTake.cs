using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtkTake : MonoBehaviour
{
    public event UnityAction callBack;
    public void takeDmg()
    {
        callBack?.Invoke();
    }
   
}
