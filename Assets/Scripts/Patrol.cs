using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Patrol : NPCBaseFSM
{
    private List<Transform> targets = new List<Transform>();
    private int currentTarget;

    private void Awake()
    {
        targets = GameObject.FindGameObjectsWithTag("point").Select(x => x.transform).ToList();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentTarget = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (targets.Count == 0) return;
        transformNPC.Translate((targets[currentTarget].position - transformNPC.position).normalized * speed);

        if (Vector3.Distance(targets[currentTarget].position, transformNPC.position) < check_distance)
        {
            currentTarget++;
            linkNPC.trushAdding(2);
            if (currentTarget >= targets.Count)
            {
                currentTarget = 0;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
