using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildButton : MonoBehaviour
{
    public int buttonId;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI costText;
    // Start is called before the first frame update
    void Start()
    {
        if(NameText != null && costText != null) {
        NameText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildingName;
            costText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildCost.ToString();

        }
    }

    public void Build()
    {
       
        if(buttonId == 0)
        {
            UiManager ui = FindObjectOfType<UiManager>();
            ui.DescWinEnable();
        }
        else
        {
            BuildManager buildManager = FindObjectOfType<BuildManager>();

            buildManager.BuildID = buttonId;
        }


    }
}
   

