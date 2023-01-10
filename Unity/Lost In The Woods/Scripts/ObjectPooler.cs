using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public GameObject PooledObject;
    public int PooledAmuont;

    private List<GameObject> PooledObjects;


    // Start is called before the first frame update
    void Start()
    {
        PooledObjects = new List<GameObject>();

        for(int i = 0; i< PooledAmuont;i++)
        {
            //Adding new Objects to the pool
            GameObject NewPooledGameObject = AddObjectToPool();

            NewPooledGameObject.transform.parent = transform;
        }

    }

    private GameObject AddObjectToPool()
    {
        GameObject NewPooledGameObject = (GameObject)Instantiate(PooledObject);
        NewPooledGameObject.SetActive(false); //prova true per testing
        PooledObjects.Add(NewPooledGameObject);
        return NewPooledGameObject;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        GameObject NewPooledGameObject = AddObjectToPool();
        NewPooledGameObject.transform.parent = transform;

        return NewPooledGameObject;
    }

    public GameObject getLastPooledObject()
    {
        GameObject lastObjectOfTheList = PooledObjects[PooledObjects.Count];
        return lastObjectOfTheList;
    }
}
