using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
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
    float hungerTimer;
    public float hungerCooldown;
    float ageTimer;
    public float ageCooldwon;
    private List<Transform> foodPos;

    public bool isFull;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetPosition();
        isFull = false;
        cooldown = 10;
      
    }

    // Update is called once per frame
    void Update()
    {
        Timers();
        if (agent.remainingDistance < 0.5 || timer >= cooldown)
        {
            timer = 0;
            GetPosition();
        }
      
    }
    public void Timers()
    {
        hungerTimer += Time.deltaTime;
        ageTimer += Time.deltaTime;

        timer += Time.deltaTime;

        if (ageTimer >= ageCooldwon)
        {
            ageTimer = 0;
            age++;
            if (age >= 100)
            {
                gameObject.SetActive(false);
            }
        }
        if(hungerTimer >= hungerCooldown)
        {
            hunger--;
            hungerTimer = 0;
            if(hunger <= 0)
            {
                gameObject.SetActive(false);
            }
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
        Food[] foods = FindObjectsOfType<Food>();
       
       
       if(foods.Length > 0 && isFull == false)
        {
            GetClosestFood(foods);

         
                if (GetClosestFood(foods).gameObject.activeInHierarchy)
                {
                    agent.SetDestination(GetClosestFood(foods).transform.position);
                   
                }
                else
                {
                    agent.SetDestination(points[Random.Range(0, points.Count)].transform.position);
                }
            

        }
        else
        {
        agent.SetDestination(points[Random.Range(0, points.Count)].transform.position);

        }
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
   
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("food") && isFull == false)
        {
            collision.gameObject.GetComponent<Food>().foodStorage--;
            GetPosition();
            StartCoroutine(fed());
            hunger++;
        }
    }

    Transform GetClosestFood(Food[] Foods)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Food potentialTarget in Foods)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget;
    }
    IEnumerator fed()
    {
        isFull = true;
        yield return new WaitForSeconds(15f);
        isFull = false;
    }

}
