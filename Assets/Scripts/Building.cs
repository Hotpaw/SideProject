using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Building : MonoBehaviour
{
    Rigidbody rb;
    public string buildingName;
    public int buildCost;
    public Transform doorPoint;
    public enum BuildingType { House, Graveyard, Tavern, Food, Church}
    public BuildingType houseType;
   
    // Start is called before the first frame update
    void Start()
    {
   rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
           
        }
      
    }
}
