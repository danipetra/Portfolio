using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //Position used for generating Platforms and other game objects
    private Transform GenerationPoint;

    //Platform Pooler
    public ObjectPooler[] PlatformsPool;
    private float[] PlatformsWidhts;
    private float[] PlatformsHeights;
    private int PlatformSelector;


    //Variables used for generating coins
    [Range(0.0f,1.0f)]
    public float objectSpawnProbability = 0.25f;
    private PlatformFiller platformFiller;


    //Variables used for changing the platforms Widhts
    private float DistanceBetween;
    public float DistanceBetweenMin, DistanceBetweenMax;

    //Variables used for Changing the Platforms Heights
    public float maxHeightVariation = 3;
    public float maxReachableHeight = 80;
    private float nextPlatformHeight;
    private float previousPlatformHeight;

    //Variables to handle height with thick platforms (as Descending ones)
    private bool IsPreviousPlatformThick = false;
    private float previousThickPlatformHeight;


    
    
   
    void Start()
    {
        platformFiller = FindObjectOfType<PlatformFiller>();

        FindGenerationPoint();

        SetPlatformsWidths();

        nextPlatformHeight = transform.position.y;
    }


    void Update()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
       //Chosing the platform pooler
        PlatformSelector = Random.Range(0, PlatformsPool.Length);

        //Setting the distance of the platform
        previousPlatformHeight = nextPlatformHeight;
        DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
        SelectPlatformHeight();

        transform.position = new Vector3(transform.position.x + (PlatformsWidhts[PlatformSelector] / 2) + DistanceBetween, nextPlatformHeight, transform.position.z);

        GameObject newPlatform = PlatformsPool[PlatformSelector].GetPooledObject();

        newPlatform.transform.position = transform.position;
        newPlatform.transform.rotation = transform.rotation;

        //Spawn Coins
        if(newPlatform.GetComponent<Platform>().canHaveObjectsOn && 
            Random.Range(0.0f,1.0f) > objectSpawnProbability)
        {
            platformFiller.SpawnObjectsOnPlatform(transform.position, PlatformsWidhts[PlatformSelector], newPlatform.GetComponent<Platform>().maxNumberOfObjects);
        }

        newPlatform.SetActive(true);

    }

    private void FindGenerationPoint()
    {
        GenerationPoint = GameObject.Find("Generation Point").GetComponent<Transform>();

        if (!GenerationPoint)
        {
            Debug.LogError("Generation Point not found");
        }
    }

    private void SetPlatformsWidths()
    {
        PlatformsWidhts = new float[PlatformsPool.Length];

        for (int i = 0; i < PlatformsPool.Length; i++)
        {
            PlatformsWidhts[i] = PlatformsPool[i].PooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void SetPlatformsHeight()
    {
        PlatformsHeights = new float[PlatformsPool.Length];

        for (int i  = 0; i < PlatformsHeights.Length; i++)
        {
            PlatformsPool[i].PooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void SelectPlatformHeight()
    {
        if (ThickPlatformSelected())
        {                                                //this part doesn't work
            nextPlatformHeight = previousPlatformHeight/* - PlatformsPool[PlatformSelector].transform.position.y*/;
            
            IsPreviousPlatformThick = true;

            //storing the thick platform height
            previousThickPlatformHeight = previousPlatformHeight - PlatformsPool[PlatformSelector].PooledObject.GetComponent<BoxCollider2D>().size.y;

        }

        else
        {
            if (IsPreviousPlatformThick)
            {
                //using the previous thick platform height to spawn the next one 
                nextPlatformHeight = Random.Range(previousThickPlatformHeight - maxHeightVariation, previousThickPlatformHeight + maxHeightVariation);

                IsPreviousPlatformThick = false;
            }
            else
            {
                nextPlatformHeight = Random.Range(previousPlatformHeight - maxHeightVariation, previousPlatformHeight + maxHeightVariation);
            }
        }

        // NB! if the platform is thick this restriction doesn't work, try something else
        if(nextPlatformHeight < -maxReachableHeight)
        {
            nextPlatformHeight = -maxReachableHeight; 
        }
        if(nextPlatformHeight > maxReachableHeight)
        {
            nextPlatformHeight = maxReachableHeight;
        }
    }


}
