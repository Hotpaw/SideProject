using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BuildManager : MonoBehaviour
{
    [Tooltip("The index of buildings that should not spawn Villagers")]
    public int[] npcRegex;
    public List<Building> buildingsInScene;
    public List<Building> buildings;
    public List<GameObject> objects;
    public  List<Npc> npcs;
    UiManager uiManager;
    GameManager gameManager;

    public int BuildID;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
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
                 
                  

                    if (buildings[BuildID].GetComponent<Building>().buildCost <= gameManager.currency)
                    {
                        Building newBuilding = Instantiate(buildings[BuildID], hit.point, buildings[BuildID].transform.localRotation);
                        gameManager.ChangePoints(false, buildings[BuildID].GetComponent<Building>().buildCost, "Gold");

                        AiManager ai = FindObjectOfType<AiManager>();
                        ai.BuildNavemshSurface();
                        buildingsInScene.Add(newBuilding);
                        float offset = 1f;
                        newBuilding.transform.position = hit.point + new Vector3(0,offset, 0);

                        if (!npcRegex.Contains(BuildID))
                        {
                            Transform spawnpoint = newBuilding.GetComponent<Building>().doorPoint;
                            for (int i = 0; i < BuildID; i++)
                            {
                                Instantiate(npcs[0].gameObject, spawnpoint.position, npcs[0].transform.localRotation);
                            }

                        }
                        if(BuildID == 7)
                        {
                            Transform spawnpoint = newBuilding.GetComponent<Building>().doorPoint;
                            Instantiate(npcs[1].gameObject, spawnpoint.position, npcs[0].transform.localRotation);
                        }
                        if (BuildID == 6)
                        {
                            Transform spawnpoint = newBuilding.GetComponent<Building>().doorPoint;
                            Instantiate(npcs[2].gameObject, spawnpoint.position, npcs[0].transform.localRotation);
                        }
                        if (BuildID == 8)
                        {
                            Transform spawnpoint = newBuilding.GetComponent<Building>().doorPoint;
                            Instantiate(npcs[3].gameObject, spawnpoint.position, npcs[0].transform.localRotation);
                           
                        }
                    }
                    
                }
              
            }
        }
    }
  public void SpawnNPCS(Npc npc, Vector3 position, Quaternion rotation)
    {
        Instantiate(npc,position, rotation);
    }
}
