using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAction : BTBaseNode
{
    public delegate BTNodeStates ActionNodeFunction();

    private ActionNodeFunction btAction;

    public BTAction(ActionNodeFunction btAction)
    {
        this.btAction = btAction;
    }

    public override BTNodeStates Evaluate()
    {
        switch (btAction())
        {
            case BTNodeStates.SUCCESS:
                btNodeState = BTNodeStates.SUCCESS;
                return btNodeState;
            case BTNodeStates.FAILURE:
                btNodeState = BTNodeStates.FAILURE;
                return btNodeState;
            default:
                btNodeState = BTNodeStates.FAILURE;
                return btNodeState;

        }
    }
}
