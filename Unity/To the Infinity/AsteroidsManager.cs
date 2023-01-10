using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroid;
    [SerializeField] int numberOfAsteroidsOnAxis = 5;
    [SerializeField] int gridSpacing = 5;
    // Start is called before the first frame update
    void Start()
    {
        placeAsteroids(); 
    }

    // Update is called once per frame
    void Update()
    {
    }
    void instantiateAsteroids(int x, int y, int z)
    {
        Instantiate
            (
            asteroid, 
            new Vector3(transform.position.x + (x * gridSpacing) +asteroidOffset(),
                        transform.position.x + (y * gridSpacing) + asteroidOffset(),
                        transform.position.x + (z * gridSpacing) + asteroidOffset()),  
            Quaternion.identity);
    }
    void placeAsteroids() 
    {
        for (int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    instantiateAsteroids(x, y, z);
                    //set as Child of this
                }

            }
        }
    }

    float asteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
        
    }
}
