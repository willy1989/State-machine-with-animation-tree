using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToOre : State
{
    private OreManager oreManager;

    private MoveManager moveManager;


    protected override void SpecificSetUp(Animator animator)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();

        moveManager = animator.gameObject.GetComponent<MoveManager>();
    }

    protected override void DoAction()
    {
        if (oreManager.CurrentOreTarget != null)
            moveManager.SetDestination(oreManager.CurrentOreTarget.transform.position);
    }
}
