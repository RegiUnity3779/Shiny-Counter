using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public static class EventManager
{
    public static Action<int> UpdateCounterNumber;
    public static Action TotalCount;
    public static Action<int> UpdateTotalText;
    public static Action<int> UpdateSettingInputField;
}
