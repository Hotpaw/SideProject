using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public float hunger;
    public float faith;
    public float age;

    public List<Transform> points;

    NavMeshAgent agent;
    float timer;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetPosition();
        cooldown = 10;
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (agent.remainingDistance < 0.5 || timer >= cooldown)
        {
            timer = 0;
            GetPosition();
        }
      
    }
    public void GetPosition()
    {
        points.Clear();
        


        BuildManager buildManager = FindObjectOfType<BuildManager>();
        foreach(var building in buildManager.buildingsInScene)
        {
            points.Add(building.transform);
        }
        agent.SetDestination(points[Random.Range(0, points.Count)].transform.position);
    }
    public void OnRenderObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Building"))
            {
              
               
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           
        }
    }
    IEnumerator AvoidObject()
    {
        bool avoid = true;
        if(avoid ==true)
        {
            avoid = false;
           

        }
        yield return new WaitForSeconds(cooldown);
        avoid = true;


    }

}
