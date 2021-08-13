using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public List<GameObject> prefabList;
    public GameObject currentCollectible;
    public GameObject collectibleParent;
    public int countOfObject;
    public List<Vector3> spawnPointCenter;
    
    // Start is called before the first frame update
    void Start()
    {
        currentCollectible = prefabList[Random.Range(0, prefabList.Count)];
        // spawnPointCenter.Capacity = Random.Range(3, 5);

        for (int i = 0; i < spawnPointCenter.Count; i++)
        {
            countOfObject = Random.Range(5, 15);

            for (int j = 0; j < countOfObject; j++)
            {
                Instantiate(currentCollectible, positionChanger(spawnPointCenter[i]), 
                    Quaternion.identity, collectibleParent.transform);
            }
            
        }
    }

    private Vector3 positionChanger(Vector3 position)
    {
        Vector3 newCollectiblePosition = new Vector3(position.x + Random.Range(-2.5f, 2.5f), position.y, position.z + Random.Range(-2.5f, 2.5f));

        return newCollectiblePosition;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
