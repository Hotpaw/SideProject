using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int foodStorage;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(foodStorage == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
