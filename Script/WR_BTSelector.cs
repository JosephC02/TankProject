using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTBaseNode
{
    protected List<BTBaseNode> btNodes = new List<BTBaseNode>();

    public BTSelector(List<BTBaseNode> btNodes)
    {
        this.btNodes = btNodes;
    }

    public override BTNodeStates Evaluate()
    {
        foreach (BTBaseNode btNode in btNodes)
        {
            switch (btNode.Evaluate())
            {
                case BTNodeStates.FAILURE:
                    continue;
                case BTNodeStates.SUCCESS:
                    btNodeState = BTNodeStates.SUCCESS;
                    return btNodeState;
                default:
                    continue;
            }
        }
        btNodeState = BTNodeStates.FAILURE;
        return btNodeState;
    }
}
