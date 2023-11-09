using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFoodState : StateMachineBehaviour
{
    private FoodManager foodManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foodManager = animator.gameObject.GetComponentInParent<FoodManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        foodManager.LookForFood();
    }

    private void CheckCondition(Animator animator)
    {
        if (foodManager.CurrentFoodTarget != null)
            animator.SetTrigger("GoToFood");
        else
            animator.SetTrigger("Exit");
    }
}
