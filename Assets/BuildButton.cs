using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildButton : MonoBehaviour
{
    public int buttonId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Build()
    {
        Debug.Log("BUILD " + buttonId);
    }
}
