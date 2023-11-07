using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounterHighEnoughTRUE_Condition : Condition
{
    [SerializeField] private FoodManager foodManager;

    public override bool ConditionIsTrueOrFalse()
    {
        return foodManager.FoodCounterHighEnough() == true;
    }
}
