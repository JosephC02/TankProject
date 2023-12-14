using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTBaseNode
{
    protected List<BTBaseNode> btNodes = new List<BTBaseNode>();

    public BTSequence(List<BTBaseNode> btNodes)
    {
        this.btNodes = btNodes;
    }

    public override BTNodeStates Evaluate()
    {
        bool failed = false;
        foreach (BTBaseNode btNode in btNodes)
        {
            if (failed == true)
            {
                break;
            }

            switch (btNode.Evaluate())
            {
                case BTNodeStates.FAILURE:
                    btNodeState = BTNodeStates.FAILURE;
                    failed = true;
                    break;
                case BTNodeStates.SUCCESS:
                    btNodeState = BTNodeStates.SUCCESS;
                    continue;
                default:
                    btNodeState = BTNodeStates.FAILURE;
                    failed = true;
                    break;

            }
        }
        return btNodeState;
    }
}
