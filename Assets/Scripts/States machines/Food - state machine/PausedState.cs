using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PausedState : StateMachineBehaviour
{
    private MoveManager moveManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveManager = animator.gameObject.GetComponent<MoveManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DoAction();
    }

    private void DoAction() 
    {
        moveManager.StopMovement();
    }
}
