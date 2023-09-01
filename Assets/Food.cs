using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   
    public int foodStorage;
    public int maxFoodstorage;
    float timer;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        foodStorage = maxFoodstorage;
        cooldown = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldown)
        {
            timer = 0;
            foodStorage++;
            if(foodStorage > maxFoodstorage)
            {
                foodStorage = maxFoodstorage;
            }
        }
    }
}
