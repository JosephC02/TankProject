using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseState
{
    public abstract void StateEnter();
    public abstract Type StateUpdate();
    public abstract void StateExit();

    public static bool Selection(List<string> conditions,Dictionary<string,bool> facts)
    {
        foreach (string item in conditions) 
        {
            if (facts[item]) { return true; }
        }
        return false;
    }
}