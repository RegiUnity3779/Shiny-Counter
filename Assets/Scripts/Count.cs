using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Count", menuName ="New Count")]
public class Count : ScriptableObject
{
    public int numberOfCounters;
    public CounterData[] counters;
    public int totalCount;
}
