using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBaseCloseEnough_Condition : Condition
{
    [SerializeField] private OreManager oreManager;

    protected override bool conditionResult()
    {
        return oreManager.IsBaseCloseEnough();
    }
}
