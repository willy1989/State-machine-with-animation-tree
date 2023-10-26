using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchOreState : StateMachineBehaviour
{
    private OreManager oreManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        oreManager.LookForOre();
    }

    private void CheckCondition(Animator animator)
    {
        if (oreManager.CurrentOreTarget != null)
            animator.SetTrigger("GoToOre");
        else
            animator.SetTrigger("Exit");
    }
}