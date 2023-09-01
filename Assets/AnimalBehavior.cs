using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    float timer;
    public float cooldown;
   public  List<Transform> destinations;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        GetDestination();
        Tree[] trees = FindObjectsOfType<Tree>();
      
        foreach (Tree tree in trees)
        {

            destinations.Add(tree.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldown) {
            timer = 0;
            GetDestination();
        }
    }
    public void GetDestination()
    {
       
        if(destinations.Count > 0)
        {
            agent.SetDestination((destinations[Random.Range(0,destinations.Count)].transform.position));
        }
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
}
