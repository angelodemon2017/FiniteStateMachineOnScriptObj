using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDropTrushes : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformNPC.Translate((placeTrushDropDown.position - transformNPC.position).normalized * speed);
        if (Vector3.Distance(placeTrushDropDown.position, transformNPC.position) < check_distance)
        {
            linkNPC.resetTrush();
        }
    }
}
