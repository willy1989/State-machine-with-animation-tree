using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchOreState : StateMachineBehaviour
{
    private OreManager oreManager;

    private FoodManager foodManager;

    [SerializeField] private ConditionStatePair conditionStatePair;

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
        oreManager.LookForOre();
    }

    private void CheckCondition(Animator animator)
    {
        if (foodManager.FoodCounterHighEnough() == false)
            animator.SetTrigger("FoodStateMachine");

        else if (oreManager.CurrentOreTarget != null)
            animator.SetTrigger("GoToOre");
    }
}
