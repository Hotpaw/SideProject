using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildButton : MonoBehaviour
{
    public int buttonId;
    public string buttonName;
    public string buttonDescription;
    // Start is called before the first frame update
    void Start()
    {
        
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
   

