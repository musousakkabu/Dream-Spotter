using UnityEngine;
using System;

class CustomTimer: ICustomTimer
{
    private float limitTime;
    private bool isTimerActive;
    private float nowLeftTime;
    private Action timeupEvent;

    public CustomTimer(float limitTime, Action timeupEvent) 
    {
        this.limitTime = limitTime;
        this.isTimerActive = false;
        this.nowLeftTime = limitTime;
        this.timeupEvent = timeupEvent;
    }

    public void StartTimer() 
    {
        isTimerActive = true;
    }

    public void StopTimer() 
    {
        isTimerActive = false;
    }

    public void ResetTimer()
    {
        isTimerActive = false;
        nowLeftTime = limitTime;
    }

    public void DecreaseSec(float decreaseSec)
    {
        nowLeftTime -= decreaseSec;
    }

    public void DecreaseFrame()
    {
        nowLeftTime -= Time.deltaTime;
        if (nowLeftTime <= 0)
        {
            activateTimeUpEvent();
        }
    }

    public void increaseTimer(float increaseSec)
    {
        nowLeftTime += increaseSec;
    }

    public void activateTimeUpEvent()
    {
        ResetTimer();
        timeupEvent();
    }

    public float getTime() 
    {
        return nowLeftTime;
    }

    public bool getIsTimerActive()
    {
        return isTimerActive;
    }
}