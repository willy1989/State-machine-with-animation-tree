using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringOreHome : StateMachineBehaviour
{
    private MoveManager moveManager;

    private OreManager oreManager;

    private ConditionStatePair[] conditionStatePairs;

    [SerializeField] private string conditionStatePairKey;

    private bool isSetUpDone = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isSetUpDone == false)
        {
            oreManager = animator.gameObject.GetComponent<OreManager>();

            moveManager = animator.gameObject.GetComponent<MoveManager>();

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
        DoAction();
        CheckCondition(animator);
    }

    private void DoAction()
    {
        moveManager.SetDestination(oreManager.baseBuildingLocation);
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
                    animator.SetTrigger(stateName);
                    break;
                }
            }
        }
    }
}
