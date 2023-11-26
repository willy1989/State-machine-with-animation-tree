using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchOreState : State
{
    private OreManager oreManager;

    protected override void SpecificSetUp(Animator animator)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();
    }

    protected override void DoAction()
    {
        oreManager.LookForOre();
    }
}
