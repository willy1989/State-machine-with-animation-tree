using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStatePairs : MonoBehaviour
{
    [SerializeField] private ConditionStatePair[] pairs;

    public ConditionStatePair[] Pairs => pairs;
}
