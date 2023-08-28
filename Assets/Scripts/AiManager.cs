using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AiManager : MonoBehaviour
{
    public NavMeshSurface navMesh;
    // Start is called before the first frame update
    void Start()
    {
      navMesh = FindObjectOfType<NavMeshSurface>();
        navMesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuildNavemshSurface()
    {
        navMesh.UpdateNavMesh(navMesh.navMeshData);
    }

  
}
