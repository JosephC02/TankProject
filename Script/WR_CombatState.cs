using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CombatState : BaseState
{
    private SmartTank _myTank;

    public CombatState(SmartTank myTank)
    {
        _myTank = myTank;
    }

    public override void StateEnter()
    {
        Debug.Log("Combat State");
        _myTank.facts[_myTank.COMBATSTATE] = true;
    }

    public override Type StateUpdate()
    {
        if (_myTank.facts[_myTank.ENEMYTANKFOUND] || _myTank.facts[_myTank.BASEFOUND]) { _myTank.Attack(); }
        else return typeof(RoamState);
        return null;
    }

    public override void StateExit()
    {
        _myTank.facts[_myTank.COMBATSTATE] = false;
    }
}

/*
public class CloseCombatState : BaseState
{
    SmartTank _myTank;
    public CloseCombatState(SmartTank myTank)
    {
        _myTank = myTank;
    }

    public override void StateEnter()
    {
        Debug.Log("Close Combat");
        _myTank.facts[_myTank.CLOSECOMBATSTATE] = true;
    }

    public override void StateExit()
    {
        _myTank.facts[_myTank.CLOSECOMBATSTATE] = false;
    }

    public override Type StateUpdate()
    {
        Debug.Log(_myTank.enemyTanksFound);
        if (_myTank.facts[_myTank.ENEMYTANKFOUND] || _myTank.facts[_myTank.BASEFOUND]) { _myTank.Attack(); }
        else { return typeof(CombatState); }
        return typeof(RoamState);
    }
}

public class LongCombatState : BaseState
{
    SmartTank _myTank;
    public LongCombatState(SmartTank myTank)
    {
        _myTank = myTank;
    }

    public override void StateEnter()
    {
        Debug.Log("Long Combat");
        _myTank.facts[_myTank.LONGCOMBATSTATE] = true;
    }

    public override void StateExit()
    {
        _myTank.facts[_myTank.LONGCOMBATSTATE] = false;
    }

    public override Type StateUpdate()

    {
        Debug.Log(_myTank.enemyTanksFound);
        if (_myTank.facts[_myTank.ENEMYTANKFOUND] || _myTank.facts[_myTank.BASEFOUND]) { _myTank.Attack(); }
        else { return typeof(CombatState); }
        return null;
    }
}
*/