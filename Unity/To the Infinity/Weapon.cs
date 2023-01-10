using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Magazine;
    private ObjectPooler BulletsPooler;
    private float weaponRange;

    // Start is called before the first frame update

    private void Awake()
    {
        BulletsPooler = Magazine.GetComponent<ObjectPooler>(); 
    }


    void Start()
    {
        //check the type of magazine you have
        if(Magazine.GetComponent<ObjectPooler>().PooledObject.tag == "Missle")
        {
            weaponRange = Magazine.GetComponent<ObjectPooler>().
            PooledObject.GetComponent<Missle>().maxDistance;

            //use it'a firerate 
        }

    

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * weaponRange, Color.yellow);
    }
    
    public void fireBullet()
    {
        //if it's a missle fire using it's firerate
        Debug.Log("BANG!");
        GameObject firedBullet = BulletsPooler.GetPooledObject();

        firedBullet.transform.position = transform.position;
        firedBullet.transform.rotation = transform.rotation;

        if(firedBullet.tag == "Missle")
        {
            firedBullet.GetComponent<Missle>().setStartingZ(transform.position.z);
        }

        firedBullet.SetActive(true);

    }

    //Raycasting is also used for enemy ships to decide the best action
    //is the enemy in sight? shoot
    //is not? cast ray in different direction
    //doesn't see the player even with rays? start moving in one of the directions
    public Vector3 castRay()
    {
        RaycastHit hit;

        Vector3 myDirection = transform.TransformDirection(Vector3.forward) * weaponRange;

        if (Physics.Raycast(transform.position, myDirection, out hit))
        {
            Debug.Log("Hit:" + hit.transform.name);
            return hit.point; //return the transform of the point of hit
        }
        else
        {
            Debug.Log("Miss:" + hit.transform.name);
            return transform.position + (transform.forward) * weaponRange;
        }
    }



}
