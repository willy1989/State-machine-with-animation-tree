using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentFoodTargetNULL_Condition : Condition
{
    [SerializeField] private FoodManager foodManager;

    protected override bool conditionResult()
    {
        return foodManager.CurrentFoodTarget == null;
    }
}
