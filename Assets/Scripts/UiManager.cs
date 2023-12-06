using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UiManager : MonoBehaviour
{
    public GameObject[] descWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public void DescWinEnable(int a)
    {
        foreach (GameObject go in descWindow)
        {
            if(go.activeInHierarchy)
            {
            go.SetActive(false);
                return;
            }
        }
        if(a == 0)
        {
            if (descWindow[0].activeInHierarchy)
            {

                descWindow[0].SetActive(false);
            }
            else
            {
                descWindow[0].SetActive(true);
            }
        }
        if(a == 1)
        {
            if (descWindow[1].activeInHierarchy)
            {

                descWindow[1].SetActive(false);
            }
            else
            {
                descWindow[1].SetActive(true);
            }
        }
       
    }

}
