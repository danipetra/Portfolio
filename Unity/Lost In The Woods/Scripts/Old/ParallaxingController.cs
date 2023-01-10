using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxingController : MonoBehaviour
{

    public ObjectPooler[] backgroundsPools;
    public float[] parallaxLayerSpeedMultiplier;

    private Transform cameraTransform;
    private Transform GenerationPoint;
    private void Awake()
    {

        GenerationPoint = GameObject.Find("Generation Point").GetComponent<Transform>();

        cameraTransform = Camera.main.transform;

        //setting a negative parallaxing speed for each layer depending on z position
        //TODO set a z in the prefabs for each layer
        for (int i = 0; i < backgroundsPools.Length; i++)
        {
            parallaxLayerSpeedMultiplier[i] = backgroundsPools[i].PooledObject.transform.position.z * - 1;
        }
    }

    private void Update()
    {
        //per ogni livello dei backgroundpools, se uno di loro ha
        //fare un for
        for(int i = 0; i<backgroundsPools.Length; i++)
        {
            GameObject lastPooledObject = backgroundsPools[i].getLastPooledObject();

            if (lastPooledObject.transform.position.x < GenerationPoint.position.x)
            {
                //genera un nuovo background
                GameObject newBackground = backgroundsPools[0].GetPooledObject();

                //setta la posizione del background = alla FINE precedente
                newBackground.transform.position = new Vector3(0, lastPooledObject.transform.position.y, lastPooledObject.transform.position.z);
                newBackground.SetActive(true);

            }
        }
        

        //aggiornare la posizione di tutti i layers di background

    }





}


