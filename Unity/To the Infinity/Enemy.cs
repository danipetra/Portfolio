using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    private Transform target;
    [SerializeField] float rotationalDamp = 1.25f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        base.move();
        isInFront();
    }

    private void Turn()
    {
        Vector3 diffPosition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(diffPosition);

        //this adds some delay for turning
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    private bool isInFront()
    {
        Vector3 directionToTarget = transform.position - target.position;

        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90 &&Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, target.position,Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, target.position, Color.red);
        return false;
        
    
    }

    private bool haveLineOfSight()
    {
        RaycastHit hit;

        return false;
    }

    private void Attack()
    {

    }
}
