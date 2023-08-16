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
    /// ��Ӽ�ʱ��
    /// </summary>
    public Timer AddTimer(E_EventC name, Action onFinished, float delayTime, bool isLoop = false)
    {
        //���ȿ������ö������Ƿ������õļ�ʱ�� ���û�оͳ�ʼ��һ�� ����о��ó�����
        //var timer = mAvailableQueue.Count == 0 ? new Timer() : mAvailableQueue.Dequeue();
        Timer timer = new Timer();
        //�����ǵ��ÿ�ʼ��ʱ����
        timer.Start(name, onFinished, delayTime, isLoop);
        //���뵽�����б�������
        timers.Add(timer);
        timerNames.Add(name);
        //mUpdateList.Add(timer);
        //������÷��ص�ǰ��ʱ���������� �ֶ�ֹͣ����һЩ����
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
    /// ���¼�ʱ��
    /// </summary>
    private void Update()
    {
        //�����ж��Ƿ��м�ʱ������Ҫ����
        if (timers.Count == 0) return;
        //����оͱ����б� �ж��б��ж����Ƿ������״̬
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
            //�����ǰ��ʱ�����Ѿ���� �ʹӸ����б���ɾ������ӵ������б��Ҳ���ִ�и���
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
