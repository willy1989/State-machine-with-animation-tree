using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOreTargetNULL_Condition : Condition
{
    [SerializeField] private OreManager oreManager;

    protected override bool conditionResult()
    {
        return oreManager.CurrentOreTarget == null;
    }
}
