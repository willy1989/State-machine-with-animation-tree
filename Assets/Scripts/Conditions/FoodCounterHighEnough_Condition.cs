using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounterHighEnough_Condition : Condition
{
    [SerializeField] private FoodManager foodManager;

    protected override bool conditionResult()
    {
        return foodManager.FoodCounterHighEnough();
    }
}
