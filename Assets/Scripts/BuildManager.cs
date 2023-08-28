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
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
    


        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && !uiManager.IsPointerOverUIObject())
            {
                int num = Random.Range(0, buildings.Count);

                if (!hit.collider.CompareTag("Building"))
                {
                   GameObject Building = Instantiate(buildings[num], hit.point, buildings[num].transform.localRotation);
                   
                    AiManager ai = FindObjectOfType<AiManager>();
                    ai.BuildNavemshSurface();
                    buildingsInScene.Add(Building);
                    Transform spawnpoint = Building.GetComponent<Building>().doorPoint;

                    for (int i = 0; i < Random.Range(1,2); i++)
                    {
                        Instantiate(npcs[0].gameObject, spawnpoint.position , npcs[0].transform.localRotation);
                    }
                }
              
            }
        }
    }
  
}
