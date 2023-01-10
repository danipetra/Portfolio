using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFiller : MonoBehaviour
{

    public ObjectPooler coinPooler;
    public float coinSpawnProbability = 0.5f;

    public ObjectPooler gemPooler;
    public float gemSpawnProbability = 0.05f;


    public ObjectPooler spikePooler;
    public float spikeSpawnProbability = 0.2f;
    private bool spikeSpawnedOnPlatform;
    
    public float distanceBetweenPlatformObjects = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        spikeSpawnedOnPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnObjectsOnPlatform(Vector3 platformCenter,float platformWidht, int maxNumberOfObjects)
    {
        float platformStartPosition = platformCenter.x - (platformWidht / 2) ;

        for(int i = 1; i<= maxNumberOfObjects; i++)
        {
            float range = Random.Range(0f, 1f);
            Vector3 platformObjectPosition = new Vector3(platformStartPosition + distanceBetweenPlatformObjects * i, platformCenter.y + 1, platformCenter.z);

            //chosing what object spawn
            if (range< gemSpawnProbability)
            {
                GameObject gem = SpawnPlatformObject(platformObjectPosition, gemPooler);
            }

            else if (!spikeSpawnedOnPlatform && range < spikeSpawnProbability)
            {
                GameObject spike = SpawnPlatformObject(platformObjectPosition, spikePooler);
                spikeSpawnedOnPlatform = true;
            }

            else if (range < coinSpawnProbability)
            {
                GameObject coin = SpawnPlatformObject(platformObjectPosition, coinPooler);
            }

        }
        spikeSpawnedOnPlatform = false;
    }




    public void SpawnCOinsOnPlatformFromCenter(Vector3 startPosition, int numberOfCoins)
    {
        GameObject firstCoin = coinPooler.GetPooledObject();

        firstCoin.transform.position = startPosition;

        firstCoin.SetActive(true);

        for (int i = 1; i < numberOfCoins - 1; i++)
        {

            //spawn a coin
                GameObject leftCoin = coinPooler.GetPooledObject();

                leftCoin.transform.position = new Vector3(startPosition.x - distanceBetweenPlatformObjects * i, startPosition.y, startPosition.z);

                leftCoin.SetActive(true);

                GameObject rightCoin = coinPooler.GetPooledObject();

                rightCoin.transform.position = new Vector3(startPosition.x + distanceBetweenPlatformObjects * i, startPosition.y, startPosition.z);

                rightCoin.SetActive(true);
            //}
          
        }

    }

    public GameObject SpawnPlatformObject(Vector3 startPosition,ObjectPooler objectPooler)
    {
        GameObject platformObject = objectPooler.GetPooledObject();
        platformObject.transform.position = startPosition;

        platformObject.SetActive(true);
        return platformObject;
    }

}

