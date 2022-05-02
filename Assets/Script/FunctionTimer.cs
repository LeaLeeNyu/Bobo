using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    private Action action;
    public float timer;
    private bool isDestoryed = false;

    public FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }

    public void UpdateTimer()
    {
        if (!isDestoryed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //trigger the action
                action();
                DestorySelf();
            }
        }
    }

    private void DestorySelf()
    {
        isDestoryed = true;
    }

    public void ResetSelf(float timer)
    {
        this.timer = timer;
        isDestoryed = false;
    }
}
