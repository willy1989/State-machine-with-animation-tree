using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreTargetCloseEnough_Condition : Condition
{
    [SerializeField] private OreManager oreManager;

    protected override bool conditionResult()
    {
        return oreManager.IsOreTargetCloseEnough();
    }
}
