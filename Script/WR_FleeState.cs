using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class FleeState : BaseState
{
    private SmartTank _myTank;
    private float t;

    public FleeState(SmartTank MyTank) 
    {
        _myTank = MyTank;
    }
    public override void StateEnter()
    { 
        _myTank.facts[_myTank.FLEESTATE] = true;
        t = 0;
    }

    public override void StateExit()
    {
        _myTank.facts[_myTank.FLEESTATE] = false;
    }

    public override Type StateUpdate()
    {
        t += Time.deltaTime;
        if(t < 5) 
        {
            _myTank.Fleeing();
        }
        else if (_myTank.checkForEnemy())
        {
            t=0;
            return typeof(RoamState);
        }
        return null;
    }
}
