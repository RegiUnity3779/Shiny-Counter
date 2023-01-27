using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public Counter[] avaliableCounters;

    public GameObject buttonManager;
    public int numberOfCounters;
    public int totalCount;

    private void OnEnable()
    {
        EventManager.TotalCount += TotalCount;
        EventManager.UpdateCounterNumber += UpdateCounterNumber;
        
    }
    private void OnDisable()
    {
        EventManager.TotalCount -= TotalCount;
        EventManager.UpdateCounterNumber -= UpdateCounterNumber;
        

    }

    public void UpdateCounterNumber(int counter)
    {
        numberOfCounters = counter;

        

        for (int i = 0; i < avaliableCounters.Length; i++)
        {

            if ( i < numberOfCounters)
            {
                if (!avaliableCounters[i].gameObject.activeInHierarchy)
                {
                    avaliableCounters[i].curRate = 1;
                    avaliableCounters[i].UpdateRateText();
                    avaliableCounters[i].ResetCounter();
                    avaliableCounters[i].gameObject.SetActive(true);
                }

            }
            else
            {
                avaliableCounters[i].gameObject.SetActive(false);
            }

       
        }
        TotalCount();
    }
    


    void TotalCount()
    {
        int a = 0;

        for (int i = 0; i < avaliableCounters.Length; i++)
        {
            if (avaliableCounters[i].gameObject.activeInHierarchy)
            {
                a += avaliableCounters[i].curCount;
            }
        }

        totalCount = a;

        if (a < 0)
        {
            totalCount = 0;
        }
        else
        {
            totalCount = a;
        }
        
        EventManager.UpdateTotalText(totalCount);

    }
    public void ResetTotalCounter()
    {
        totalCount = 0;
        EventManager.UpdateTotalText(totalCount);
    }

    public void UpdateCounterNameSetting()
    {
        EventManager.UpdateSettingInputField(numberOfCounters);

    }

}
