using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BuildManager : MonoBehaviour
{
    public List<GameObject> buildingsInScene;
    public List<GameObject> buildings;
    public  List<Npc> npcs;
    UiManager uiManager;

    public int BuildID;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
    


        if (Input.GetMouseButtonDown(0) && BuildID != 0)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && !uiManager.IsPointerOverUIObject())
            {
               

                if (!hit.collider.CompareTag("Building") && !hit.collider.CompareTag("Enviroment"))
                {
                   GameObject newBuilding = Instantiate(buildings[BuildID], hit.point, buildings[BuildID].transform.localRotation);
                   
                   
                    AiManager ai = FindObjectOfType<AiManager>();
                    ai.BuildNavemshSurface();
                    buildingsInScene.Add(newBuilding);
                   
                    if(BuildID != 4 && BuildID != 5)
                    {
                        Transform spawnpoint = newBuilding.GetComponent<Building>().doorPoint;
                        for (int i = 0; i < Random.Range(1,5); i++)
                        {
                            Instantiate(npcs[0].gameObject, spawnpoint.position , npcs[0].transform.localRotation);
                        }

                    }
                }
              
            }
        }
    }
  
}
