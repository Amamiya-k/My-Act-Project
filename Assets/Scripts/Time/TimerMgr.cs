using System;
using System.Collections.Generic;
public class TimerMgr : SingletonAutoMono<TimerMgr>
{
    // Dictionary<string, Timer> timersDic = new Dictionary<string, Timer>();
    private List<Timer> timers = new List<Timer>();
    private List<E_EventC> timerNames = new List<E_EventC>();

    //private List<Timer> mUpdateList = new List<Timer>();
    //private Queue<Timer> mAvailableQueue = new Queue<Timer>();

    /// <summary>
    /// 添加计时器
    /// </summary>
    public Timer AddTimer(E_EventC name, Action onFinished, float delayTime, bool isLoop = false)
    {
        //首先看看可用队列中是否有闲置的计时器 如果没有就初始化一个 如果有就拿出来用
        //var timer = mAvailableQueue.Count == 0 ? new Timer() : mAvailableQueue.Dequeue();
        Timer timer = new Timer();
        //这里是调用开始计时方法
        timer.Start(name, onFinished, delayTime, isLoop);
        //加入到更新列表参与更新
        timers.Add(timer);
        timerNames.Add(name);
        //mUpdateList.Add(timer);
        //这里可用返回当前计时器对象用于 手动停止或做一些操作
        return timer;
    }
    public void StopTimer(E_EventC name)
    {
        if(timerNames.Contains(name))
        {
            int index= timerNames.IndexOf(name);
            //print(index);
            //print(timerNames.IndexOf(name));
            //print(timerNames.IndexOf(name));
            timerNames.RemoveAt(index);
            timers.RemoveAt(index);
        }
    }
    /// <summary>
    /// 更新计时器
    /// </summary>
    private void Update()
    {
        //首先判断是否有计时任务需要更新
        if (timers.Count == 0) return;
        //如果有就遍历列表 判断列表中对象是否处于完成状态
        for (int i = 0; i < timers.Count; i++) 
        {
            if (timers[i].isFinished)
            {
                StopTimer(timers[i].name);
            }
            timers[i].Update();
        }
        /*foreach(var timer in timers)
        {
            
        }
*/
        /*for (int i = timersDic.Count - 1; i >= 0; i--)
        {
            //如果当前计时任务已经完成 就从更新列表中删除并添加到可用列表且不再执行更新
            if (timersDic[i].isFinished)
            {
                mAvailableQueue.Enqueue(mUpdateList[i]);
                mUpdateList.RemoveAt(i);
                continue;
            }
            mUpdateList[i].Update();
        }*/
    }
}
