using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToFoodState : StateMachineBehaviour
{
    private FoodManager foodManager;

    private MoveManager moveManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foodManager = animator.gameObject.GetComponent<FoodManager>();

        moveManager = animator.gameObject.GetComponent<MoveManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction() 
    {
        if(foodManager.CurrentFoodTarget != null)
            moveManager.SetDestination(foodManager.CurrentFoodTarget.transform.position);
    }

    private void CheckCondition(Animator animator)
    {
        float distance = (foodManager.CurrentFoodTarget.transform.position - animator.transform.position).magnitude;

        if (distance < 0.5f &&  foodManager.CurrentFoodTarget != null)
            animator.SetTrigger("EatFood");
    }
}
