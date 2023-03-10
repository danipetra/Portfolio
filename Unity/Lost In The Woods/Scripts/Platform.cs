using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int maxNumberOfObjects;
    public bool canHaveObjectsOn;

    private GameObject deactivationPoint;
    // Start is called before the first frame update

    void Start()
    {
        deactivationPoint = GameObject.Find("Deactivation Point");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deactivationPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
