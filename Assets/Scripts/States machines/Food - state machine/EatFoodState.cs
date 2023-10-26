using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatFoodState : StateMachineBehaviour
{
    private FoodManager foodManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foodManager = animator.gameObject.GetComponent<FoodManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        foodManager.EatFood();
    }

    private void CheckCondition(Animator animator)
    {
        if(foodManager.FoodCounterHighEnough() == true)
            animator.SetTrigger("Exit");
        else
        {
            animator.SetTrigger("SearchFood");
        }
    }
}
