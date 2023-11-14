using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOre : StateMachineBehaviour
{
    private OreManager oreManager;

    private FoodManager foodManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();

        foodManager = animator.gameObject.GetComponent<FoodManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        oreManager.GrabOre();
    }

    private void CheckCondition(Animator animator)
    {
        if (foodManager.FoodCounterHighEnough() == false)
            animator.SetTrigger("FoodStateMachine");
        else
            animator.SetTrigger("BringOreHome");
    }
}
