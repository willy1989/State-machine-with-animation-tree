using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOre : State
{
    private OreManager oreManager;

    protected override void DoAction()
    {
        oreManager.DropOre();
    }

    protected override void SpecificSetUp(Animator animator)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();
    }
}
