using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChaseState : BaseState
{
    private SmartTank _myTank;

    public ChaseState(SmartTank myTank)
    {
        _myTank = myTank;
    }

    public override void StateEnter()
    {
        _myTank.facts[_myTank.CHASESTATE] = true;
        Debug.Log("ChaseState");
    }

    public override Type StateUpdate()
    {
        _myTank.Chase();
        return null;
    }

    public override void StateExit()
    {
        _myTank.facts[_myTank.CHASESTATE] = false;
    }
}
