using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchOreState : StateMachineBehaviour
{
    private OreManager oreManager;

    private ConditionStatePair[] conditionStatePairs;

    private bool isSetUpDone = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(isSetUpDone == false)
        {
            oreManager = animator.gameObject.GetComponentInParent<OreManager>();

            conditionStatePairs = animator.gameObject.GetComponent<ConditionStatePairs>().Pairs;

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
        oreManager.LookForOre();
    }

    private void CheckCondition(Animator animator)
    {
        foreach(ConditionStatePair pair in conditionStatePairs)
        {
            string stateName = pair.GetNextStateName();

            if (stateName != string.Empty)
            {
                animator.SetTrigger(stateName);
                break;
            }
                
        }
    }
}
