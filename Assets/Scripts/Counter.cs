using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public Button countButton;
    public int curCount;
    public int curRate;
    public TextMeshProUGUI curCountText;
    public TextMeshProUGUI rateText;
    public Button resetButton;
    
    public string buttonName;
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        
        
        curRate = 1;
        UpdateCounterText();
        UpdateRateText();
        ButtonNameUI();


    }

    public void IncreaseRate()
    {
        curRate++;
        UpdateRateText();
    }
    public void DecreaseRate()
    {
        curRate--;
        UpdateRateText();
    }

    public void IncreaseCount()
    {
        if(curRate == 0)
        {
            return;
        }
        if((curCount + curRate) < 0)
        {
            curCount = 0;
        }
        else
        {
            curCount += curRate;
        }
        
        UpdateCounterText();
        EventManager.TotalCount();

    }
    public void UpdateCounterText()
    {
        curCountText.text = $"{curCount}";
    }
    public void UpdateRateText()
    {
        rateText.text = $"{curRate}";
    }
    public void ResetCounter()
    {
        curCount = 0;
        curRate = 1;
        UpdateCounterText();
        UpdateRateText();
        EventManager.TotalCount();
    }

    public void UpdateButtonName( TMP_InputField field )
    {
        buttonName = field.text;
        nameText.text = buttonName;
        

    }
    public void ButtonNameUI()
    {
        nameText.text = buttonName;
    }


}
