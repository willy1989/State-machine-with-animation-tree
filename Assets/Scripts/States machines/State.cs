using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : StateMachineBehaviour
{
    [SerializeField] private string conditionStatePairKey;

    private ConditionStatePair[] conditionStatePairs;

    private bool isSetUpDone = false;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetUp(animator);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

    protected void CheckCondition(Animator animator)
    {
        foreach (ConditionStatePair pair in conditionStatePairs)
        {
            string stateName = pair.GetNextStateName();

            if (stateName != string.Empty)
            {
                animator.SetTrigger(stateName);
                return;
            }
        }
    }

    protected abstract void SpecificSetUp(Animator animator);

    protected abstract void DoAction();
}
