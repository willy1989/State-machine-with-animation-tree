using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    [SerializeField] private bool trueOrFalse;

    protected abstract bool conditionResult();

    public bool ConditionIsTRUEorFALSE()
    {
        return conditionResult() == trueOrFalse;
    }
}
