using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animals;
    public float animalCooldown;
    public float animalTimer;
    public List<Transform> TreeList;
    // Start is called before the first frame update
    void Start()
    {
        Tree[] trees = FindObjectsOfType<Tree>();
        foreach (var t in trees)
        {
            TreeList.Add(t.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animalTimer += Time.deltaTime;
        if(animalTimer > animalCooldown )
        {
            animalTimer = 0;
            CreateAnimal();

        }
        
    }
    public void CreateAnimal()
    {

        GameObject Animal = Instantiate(animals[Random.Range(0, animals.Count)], TreeList[Random.Range(0,TreeList.Count)] );
    }
}
