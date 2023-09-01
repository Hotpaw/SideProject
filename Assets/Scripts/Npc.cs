using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    NavMeshAgent agent;

    
    public enum Class { Villager, Hunter, Gravekeeper};
    [Header("Class")]
    public Class NpcClass;


    [Header("Bools")]
    public bool hungry;
    public bool happy;
    public bool working;

    [Header("Variables")]
    public float hunger;
    public float faith;
    public float age;
    public float maxAge;

    float timer;
    float ageTimer;
    float hungerTimer;
    [Header("Timers")]
    public float ageCooldwon;
    public float cooldown;
    public float hungerCooldown;

    [Header("Lists")]
    public List<Transform> foodPos;
    public List<Transform> Taverns;
    public List<Transform> points;
    public List<Transform> animals;
    [Header("Objects")]
    public GameObject graveStone;

   
   
    
 

    
    // Start is called before the first frame update
    void Start()
    {
        working = false;
        NPCDifference();
        agent = GetComponent<NavMeshAgent>();
        GetPosition();
     
        hungry = false;
      
       
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (NpcClass == Class.Villager)
        {

        VillagerTimers();
        }
        if (agent != null && agent.remainingDistance < 0.5 || timer >= cooldown)
        {
            timer = 0;
            GetPosition();
        }
      
    }
    public void VillagerTimers()
    {
        hungerTimer += Time.deltaTime;
        ageTimer += Time.deltaTime;

       

        if (ageTimer >= ageCooldwon)
        {
            ageTimer = 0;
            age++;
            checkForAge();
            if (age >= maxAge)
            {
                OnDeath();
            }
        }
        if(hungerTimer >= hungerCooldown)
        {
            hunger--;
            hungerTimer = 0;
            CheckForHunger();
            if(hunger <= 0)
            {
                OnDeath();
            }
        }
    }
    public void GetPosition()
    {
       if(NpcClass == Class.Hunter) {
            HunterPositionData();
        }
        
        if(NpcClass == Class.Villager)
        {
            VillagerOnPositionData();
        }


    }
    public void HunterPositionData()
    {
        List<Transform> trees = FindObjectOfType<SpawnManager>().TreeList;
        AnimalBehavior[] animalArray = FindObjectsOfType<AnimalBehavior>();
       
        animals.Clear();
        foreach(AnimalBehavior animal in animalArray)
        {
            if(!animals.Contains(animal.transform))
            {
                animals.Add(animal.transform);
            }
         
        }
        foreach (Transform t in trees)
        {
            if (!points.Contains(t.transform))
            {
                points.Add(t.transform);
            }
        }
        Food[] foods = FindObjectsOfType<Food>();
        foreach (var food in foods)
        {
            if (!foodPos.Contains(food.transform))
            {

                foodPos.Add(food.transform);
            }
        }
        if (!working && animals.Count > 0)
        {
           
           Debug.Log(" HUNTING");
                agent.SetDestination(GetClosestTransform(animals).transform.position);
 

        }
        
        if(working && foodPos.Count > 0)
        {
            
            agent.SetDestination(GetClosestTransform(foodPos).transform.position);
         }
       

         
     
        
    }
    public void VillagerOnPositionData()
    {


        BuildManager buildManager = FindObjectOfType<BuildManager>();
        foreach (Building building in buildManager.buildingsInScene)
        {
            if (!points.Contains(building.transform) && building.GetComponent<Building>().houseType != Building.BuildingType.Tavern && !building.CompareTag("food"))
            {

                points.Add(building.transform);
            }
            if (!Taverns.Contains(building.transform) && building.GetComponent<Building>().houseType == Building.BuildingType.Tavern && !building.CompareTag("food"))
            {
                Taverns.Add(building.transform);
            }
        }


        Food[] foods = FindObjectsOfType<Food>();
        foreach (var food in foods)
        {
            if (!foodPos.Contains(food.transform) && food.GetComponent<Food>().foodStorage > 0)
            {

                foodPos.Add(food.transform);
            }
        }



        if (foods.Length > 0 && hungry == true && happy == true)
        {
            GetClosestTransform(foodPos);
            

            if (GetClosestTransform(foodPos).gameObject.activeInHierarchy)
            {
                agent.SetDestination(GetClosestTransform(foodPos).transform.position);

            }
            else
            {
                agent.SetDestination(points[Random.Range(0, points.Count)].transform.position);
            }


        }
        else if (happy == false && Taverns.Count > 0)
        {


            agent.SetDestination(GetClosestTransform(Taverns).transform.position);


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
        if(NpcClass == Class.Villager)
        {
            if (collision.gameObject.CompareTag("food") && hungry == true)
            {
                collision.gameObject.GetComponent<Food>().foodStorage--;
                hunger += 5;
                CheckForHunger();
                GetPosition();


            }
            if (collision.gameObject.CompareTag("Building"))
            {
                if (collision.gameObject.GetComponent<Building>().houseType == Building.BuildingType.Tavern)
                    Debug.Log(" HAPPY ");
                happy = true;
            }
            else
            {
                return;
            }
        }
        if(NpcClass == Class.Hunter)
        {
            if (collision.gameObject.CompareTag("Animal") && working == false)
            {
                collision.gameObject.SetActive(false);
                working = true;

               
            }
            if (collision.gameObject.CompareTag("food") && working == true)
            {
                Debug.Log(" FOOD DELIEVERED");
                collision.gameObject.GetComponent<Food>().foodStorage += collision.gameObject.GetComponent<Food>().maxFoodstorage / 2;
                working = false;
            }
            else { return; }
        }
    
      
       
    }
    public void CheckForHunger()
    {
        if(hunger <= 5)
        {
          
            hungry = true;
           
        }
        else
        {
            hungry = false;
        }
    }
    public void checkForAge()
    {
        if(age >= maxAge / 2)
        {
            int random = Random.Range(0,100);
            if(random <= 5 && happy == true)
            {
                Debug.Log("I AM SAD AND OLD");
                happy = false;
            }
        }
    }
    public void NPCDifference()
    {
        float ownAge = Random.Range(maxAge, maxAge * 2);
        float ownHungerCooldown = Random.Range(hungerCooldown, hungerCooldown * 2);
    }

    Transform GetClosestTransform(List<Transform> list)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in list)
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
  
    public void OnDeath()
    {
        Instantiate(graveStone, transform.position, graveStone.transform.localRotation);
        gameObject.SetActive(false);
    }

}
