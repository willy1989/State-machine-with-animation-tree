using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConditionStatePair
{
    [SerializeField] private Condition condition;

    [SerializeField] private string stateName;

    public string GetNextStateName()
    {
        if(condition.ConditionIsTrueOrFalse() == true)
            return stateName;
        else
            return string.Empty;
    }
}
