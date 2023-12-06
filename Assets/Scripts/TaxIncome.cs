using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxIncome : MonoBehaviour
{
    GameManager gameManager;
    public int TaxAmount;
    public float cooldown;
    public float timer;
    [Tooltip("True Adds Currency, False Takes Currency")]
    public bool Taxing;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TaxingCheck(Taxing);
        
    }
    public void TaxingCheck(bool check)
    {

        timer += Time.deltaTime;
        if (timer > cooldown)
        {
         
            gameManager.ChangePoints(check, TaxAmount, "Gold");
            timer = 0;
        }
    }
}
