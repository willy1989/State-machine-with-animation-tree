using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFoodState : StateMachineBehaviour
{
    private FoodManager foodSearcher;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foodSearcher = animator.gameObject.GetComponent<FoodManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        foodSearcher.LookForFood();
    }

    private void CheckCondition(Animator animator)
    {
        if (foodSearcher.CurrentFoodTarget != null)
            animator.SetTrigger("GoToFood");
    }
}
