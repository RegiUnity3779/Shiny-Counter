using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountData", menuName =("NewCountData"))]
public class CounterData : ScriptableObject
{
    public string buttonName; 
    public int curCount;
    public int curRate;
}
