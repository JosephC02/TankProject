using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTNodeStates
{
    SUCCESS,
    FAILURE,
}


public abstract class BTBaseNode 
{
   
    protected BTNodeStates btNodeState;

    public BTNodeStates BTNodeState
    {
        get { return btNodeState; }
    }

    public abstract BTNodeStates Evaluate();
}
