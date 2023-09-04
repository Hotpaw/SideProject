using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI faithText;

    public int currency;
    public int faith;
    // Start is called before the first frame update
    void Start()
    {
       
        faith = 0;
        currencyText.text = currency.ToString();
        faithText.text = faith.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            ChangePoints(true, 100, "Gold");

        }
    }
    public void ChangePoints(bool type, int amount, string name)
    {

        switch (name)
        {
            case "Gold":
                if (type == true)
                {
                    currency += amount;
                }
                else
                {
                    currency -= amount;
                }
                break;
            case "Faith":
                if (type == true)
                {
                    faith += amount;
                }
                else
                {
                    faith -= amount;
                }
                break;



        }
        currencyText.text = currency.ToString();
        faithText.text = faith.ToString();
    }
}
