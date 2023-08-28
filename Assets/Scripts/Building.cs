using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Building : MonoBehaviour
{
    Rigidbody rb;
    public Transform doorPoint;
   
    // Start is called before the first frame update
    void Start()
    {
   rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 0)
        {

        rb.velocity = Vector3.zero;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
           
        }
      
    }
}
