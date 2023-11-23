using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : StateMachineBehaviour
{
    [SerializeField] private string conditionStatePairKey;

    [SerializeField] private ConditionStatePair[] conditionStatePairs;

    private bool isSetUpDone = false;


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
        CheckCondition(animator);
    }

    protected void SetUp(Animator animator)
    {
        if (isSetUpDone == false)
        {
            ConditionStatePairGroup[] conditionStateGroups = animator.gameObject.GetComponentsInChildren<ConditionStatePairGroup>();

            foreach (ConditionStatePairGroup group in conditionStateGroups)
            {
                if (group.GroupName == conditionStatePairKey)
                {
                    conditionStatePairs = group.Pairs;
                    break;
                }
            }

            SpecificSetUp(animator);

            isSetUpDone = true;
        }
    }

    protected abstract void SpecificSetUp(Animator animator);

    protected abstract void DoAction();

    protected void CheckCondition(Animator animator)
    {
        foreach (ConditionStatePair pair in conditionStatePairs)
        {
            string stateName = pair.GetNextStateName();

            if (stateName != string.Empty)
            {
                if (stateName == "Exit")
                {
                    animator.Play("Exit");
                }

                else
                {
                    animator.SetTrigger(stateName);
                    break;
                }
            }
        }
    }
}
