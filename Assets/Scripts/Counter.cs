using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public Button countButton;
    public CounterData data;
  
    public TextMeshProUGUI curCountText;
    public TextMeshProUGUI rateText;
    public Button resetButton;

    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        UpdateCounterText();
        UpdateRateText();
        ButtonNameUI();


    }

    public void IncreaseRate()
    {
        data.curRate++;
        UpdateRateText();
    }
    public void DecreaseRate()
    {
        data.curRate--;
        UpdateRateText();
    }

    public void IncreaseCount()
    {
        if(data.curRate == 0)
        {
            return;
        }
        if((data.curCount + data.curRate) < 0)
        {
            data.curCount = 0;
        }
        else
        {
            data.curCount += data.curRate;
        }
        
        UpdateCounterText();
        EventManager.TotalCount();

    }
    public void UpdateCounterText()
    {
        curCountText.text = $"{data.curCount}";
    }
    public void UpdateRateText()
    {
        rateText.text = $"{data.curRate}";
    }
    public void ResetCounter()
    {
        data.curCount = 0;
        data.curRate = 1;
        UpdateCounterText();
        UpdateRateText();
        EventManager.TotalCount();
    }

    public void UpdateButtonName( TMP_InputField field )
    {
        data.buttonName = field.text;
        nameText.text = data.buttonName;
        

    }
    public void ButtonNameUI()
    {
        nameText.text = data.buttonName;
    }


}
