using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStatePair : MonoBehaviour
{
    [SerializeField] private Condition condition;

    [SerializeField] private string stateName;

    public string GetNextStateName()
    {
        if(condition.ConditionIsTRUEorFALSE() == true)
            return stateName;
        else
            return string.Empty;
    }
}
