using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsteadyPlatform : Platform
{
    [Range(0f,1f)]
    public float timeBeforeCollapsing = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(startCollapsing(timeBeforeCollapsing));
        }
    }

    IEnumerator startCollapsing(float timeBeforeCollapsing)
    {
        yield return new WaitForSeconds(timeBeforeCollapsing);
        GetComponent<Rigidbody2D>().gravityScale = 20;
    }
}
