using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOre : State
{
    private OreManager oreManager;

    protected override void SpecificSetUp(Animator animator)
    {
        oreManager = animator.gameObject.GetComponent<OreManager>();
    }

    protected override void DoAction()
    {
        oreManager.GrabOre();
    }
}
