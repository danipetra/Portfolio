using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float speed;
    public float damage;
    [Range(10f, 900f)]
    public float fireRate;

    private float startingZ;
    public float maxDistance = 1000;

    private float timeUntilNextMissle = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DO NOT USE IF FOR BEAMS
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkRange();
    }

    private void move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ship")
        {
            //for now, this allows friendly fire
            other.gameObject.GetComponent<Ship>().health -= damage;
        }

        gameObject.SetActive(false);
    }

    private void checkRange()
    {
        if(transform.position.z >= getStartingZ() + maxDistance)
        {
            gameObject.SetActive(false);
            
            
        }
    }

    public float getStartingZ()
    {
        return startingZ;
    }

    public void setStartingZ(float z)
    {
        startingZ = z;
    }
}
