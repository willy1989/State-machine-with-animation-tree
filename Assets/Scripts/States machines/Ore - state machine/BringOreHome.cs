using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringOreHome : State
{
    private MoveManager moveManager;

    private OreManager oreManager;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    protected override void DoAction()
    {
        moveManager.SetDestination(oreManager.baseBuildingLocation);
    }

    protected override void SpecificSetUp(Animator animator)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();

        moveManager = animator.gameObject.GetComponent<MoveManager>();
    }
}
