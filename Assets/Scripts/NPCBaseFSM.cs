using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    protected Transform transformNPC;
    protected NPCAI linkNPC;
    [SerializeField] protected Transform basaTransform;
    [SerializeField] protected Transform placeTrushDropDown;
    [SerializeField] protected float check_distance = 0.1f;
    protected float speed 
    {
        get
        {
            return linkNPC.speed;
        }
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformNPC = animator.transform;
        linkNPC = transformNPC.GetComponent<NPCAI>();
        basaTransform = linkNPC.transformBasaOil;
        placeTrushDropDown = linkNPC.transformTrushStorage;
    }
}
