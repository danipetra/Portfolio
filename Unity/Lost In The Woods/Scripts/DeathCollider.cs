using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private float StartingYPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartingYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, StartingYPosition);    
    }
}
