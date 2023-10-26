using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToOre : StateMachineBehaviour
{
    private OreManager oreManager;

    private MoveManager moveManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();

        moveManager = animator.gameObject.GetComponent<MoveManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        if (oreManager.CurrentOreTarget != null)
            moveManager.SetDestination(oreManager.CurrentOreTarget.transform.position);
    }

    private void CheckCondition(Animator animator)
    {
        float distance = (oreManager.CurrentOreTarget.transform.position - animator.transform.position).magnitude;

        if (distance < 0.5f && oreManager.CurrentOreTarget != null)
        {
            //animator.SetTrigger("GrabOre");
        }

    }
}
