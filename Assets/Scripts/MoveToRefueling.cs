using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRefueling : NPCBaseFSM
{


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformNPC.Translate((basaTransform.position - transformNPC.position).normalized * speed);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
