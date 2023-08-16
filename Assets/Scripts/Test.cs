using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //EventCenter.GetInstance().AddEventListener<string>("LoadCharacter", P);
        //TimerMgr.GetInstance().AddTimer(T, 2, false);
        //TimerMgr.GetInstance().AddTimer(T, 3, false);
    }

    public void T()
    {
        //print("Timer");
    }

    public void P(string info)
    {
        print(info);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
