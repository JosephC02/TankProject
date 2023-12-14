using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState CurrentState { get; private set; }
    Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>();

    public void AddState(Type tState, BaseState state)
    {
        states.Add(tState, state);
        if (CurrentState != null) return;
        CurrentState = state;
        CurrentState.StateEnter();
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = states.First().Value;
            CurrentState.StateEnter();
        }

        Type state = CurrentState.StateUpdate();
        if (state != null) SwitchState(states[state]);
    }

    public void SwitchState(Type state)
    {
        SwitchState(states[state]);
    }

    void SwitchState(BaseState state)
    {
        CurrentState.StateExit();
        CurrentState = state;
        CurrentState.StateEnter();
    }
}