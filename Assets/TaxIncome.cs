using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxIncome : MonoBehaviour
{
    GameManager gameManager;
    public int TaxAmount;
    public float cooldown;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            Debug.Log(" TAXED ");
            gameManager.ChangePoints(true, TaxAmount, "Gold");
            timer = 0;
        }
        
    }
}
