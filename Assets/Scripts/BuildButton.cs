using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildButton : MonoBehaviour
{
    public int buttonId;
    public enum Type { building, upgrade }
    public Type type;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI costText;
    // Start is called before the first frame update
    void Start()
    {
        if (NameText != null && costText != null && type == BuildButton.Type.building)
        {
            NameText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildingName;
            costText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildCost.ToString();

        }
        else if (NameText != null && costText != null && type == BuildButton.Type.upgrade)
        {
            NameText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildingName;
            costText.text = FindAnyObjectByType<BuildManager>().buildings[buttonId].buildCost.ToString();
        }
    }

    public void Build()
    {

        if (buttonId == 100)
        {
            UiManager ui = FindObjectOfType<UiManager>();
            ui.DescWinEnable(0);
        }
        else if (buttonId == 200)
        {
            UiManager ui = FindObjectOfType<UiManager>();
            ui.DescWinEnable(1);
        }
        else
        {
            BuildManager buildManager = FindObjectOfType<BuildManager>();

            buildManager.BuildID = buttonId;
        }


    }
}


