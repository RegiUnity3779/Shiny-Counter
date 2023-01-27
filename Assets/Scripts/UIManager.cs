using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI totalCountText;
    public TMP_Dropdown dropdown;
    public TMP_InputField[] buttonNames;




    private void OnEnable()
    {
        EventManager.UpdateTotalText += UpdateTotalCountText;
        EventManager.UpdateSettingInputField += UpdateCounterNameSetting;
    }
    private void OnDisable()
    {
        EventManager.UpdateTotalText -= UpdateTotalCountText;
        EventManager.UpdateSettingInputField -= UpdateCounterNameSetting;

    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.UpdateCounterNumber(dropdown.value + 1);

        for (int i = 0; i < buttonNames.Length; i++)
        {
            buttonNames[i].characterLimit = 6;
        }
    }

    public void UpdateTotalCountText(int count)
    {
        totalCountText.text = $"{count}";
    }

    public void UpdateCounterNumber()
    {
        EventManager.UpdateCounterNumber((dropdown.value + 1));
    }

    public void UpdateCounterNameSetting(int a)
    {

        for (int i = 0; i < buttonNames.Length; i++)
        {
            if (i < a)
            {
                if (!buttonNames[i].gameObject.activeInHierarchy)
                {
                    buttonNames[i].gameObject.SetActive(true);
                }

            }
            else
                {
                    buttonNames[i].gameObject.SetActive(false);
                }

        }
    }
}

