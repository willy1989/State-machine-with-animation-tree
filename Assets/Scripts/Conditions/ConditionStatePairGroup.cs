using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStatePairGroup : MonoBehaviour
{
    [SerializeField] private string groupName;

    public string GroupName => groupName;

    [SerializeField] private ConditionStatePair[] pairs;

    public ConditionStatePair[] Pairs => pairs;
}
