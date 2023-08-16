using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    public E_EventC name;

    public Action actionOnFinished;

    public float finishTime;

    public float delayTime;

    public bool isLoop;

    private bool _isFinished;
    public bool isFinished=> _isFinished;
    public void Start(E_EventC n, Action action,float time,bool loop)
    {
        name = n;
        actionOnFinished = action;
        finishTime = Time.time + time;
        delayTime = time;
        isLoop = loop;
        _isFinished = false;
    }

    public void Stop() => _isFinished = true;   
    
    public void Update()
    {
        if (_isFinished) return;
        if (Time.time < finishTime) return;

        if (!isLoop) Stop();
        else finishTime = Time.time + delayTime;
        actionOnFinished?.Invoke();
    }
}
