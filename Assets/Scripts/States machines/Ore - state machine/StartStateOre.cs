using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartStateOre : StateMachineBehaviour
{
    private ConditionStatePair[] conditionStatePairs;

    [SerializeField] private string conditionStatePairKey;

    private bool isSetUpDone = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

            isSetUpDone = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckCondition(animator);
    }

    private void CheckCondition(Animator animator)
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
                    animator.Play(stateName);
                }

                break;
            }
        }
    }
}
