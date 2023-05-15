using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public Counter[] avaliableCounters;
    public Count count;
    public GameObject buttonManager;

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
        count.numberOfCounters = counter;

        

        for (int i = 0; i < avaliableCounters.Length; i++)
        {

            if ( i < count.numberOfCounters)
            {
                if (!avaliableCounters[i].gameObject.activeInHierarchy)
                {
                    avaliableCounters[i].data.curRate = 1;
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
                a += avaliableCounters[i].data.curCount;
            }
        }

        count.totalCount = a;

        if (a < 0)
        {
            count.totalCount = 0;
        }
        else
        {
            count.totalCount = a;
        }
        
        EventManager.UpdateTotalText(count.totalCount);

    }
    public void ResetTotalCounter()
    {
        count.totalCount = 0;
        EventManager.UpdateTotalText(count.totalCount);
    }

    public void UpdateCounterNameSetting()
    {
        EventManager.UpdateSettingInputField(count.numberOfCounters);

    }

}
