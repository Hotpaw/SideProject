using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void LoadScene(int id)
    {
      
        SceneManager.LoadScene(id);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
