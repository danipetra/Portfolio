using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(0f,2f)]
    public float minScale = 0f;
    [Range(0f, 10f)]
    public float maxScale = 1.2f;
    [Range(0f, 100f)]
    public float rotationScale = 50f;

    Transform myT;
    Vector3 randomRotation;

    // Start is called before the first frame update
    private void Awake()
    {
        myT = transform;
    }


    void Start()
    {

        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        myT.localScale = scale;

        randomRotation.x = Random.Range(-rotationScale, rotationScale);
        randomRotation.y = Random.Range(-rotationScale, rotationScale);
        randomRotation.z = Random.Range(-rotationScale, rotationScale);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //gameObject.SetActive(false);
        Destroy(this);
    }

}