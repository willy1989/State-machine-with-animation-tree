using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartStateOre : StateMachineBehaviour
{
    private OreManager oreManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oreManager = animator.gameObject.GetComponentInParent<OreManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    private void CheckCondition(Animator animator)
    {
        if(oreManager.IsCarryingOre() == true)
        {
            animator.SetTrigger("BringOreHome");
        }

        else if (oreManager.CurrentOreTarget == null)
            animator.SetTrigger("SearchOre");

        else if (oreManager.CurrentOreTarget != null)
        {
            float distanceToOre = (oreManager.CurrentOreTarget.transform.position - animator.transform.position).magnitude;

            if (distanceToOre > 0.5f)
                animator.SetTrigger("GoToOre");

            else if (distanceToOre < 0.5f)
                animator.SetTrigger("GrabOre");
        }
    }
}
