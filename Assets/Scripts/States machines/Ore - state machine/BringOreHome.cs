using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringOreHome : StateMachineBehaviour
{
    private MoveManager moveManager;

    private OreManager oreManager;

    private FoodManager foodManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oreManager = animator.gameObject.GetComponentInParent<OreManager>();

        moveManager = animator.gameObject.GetComponentInParent<MoveManager>();

        foodManager = animator.gameObject.GetComponentInParent<FoodManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        moveManager.SetDestination(oreManager.baseBuildingLocation);
    }

    private void CheckCondition(Animator animator)
    {
        float distance = (oreManager.baseBuildingLocation - animator.transform.position).magnitude;

        if (foodManager.FoodCounterHighEnough() == false)
            animator.SetTrigger("FoodStateMachine");

        else if (distance < 0.5f)
            animator.SetTrigger("DropOre");
    }
}
