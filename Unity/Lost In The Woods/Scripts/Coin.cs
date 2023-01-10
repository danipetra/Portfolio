using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinValue;

    private CoinManager scoreManager;
    private GameObject deactivationPoint;

    void Start()
    {
        scoreManager = FindObjectOfType<CoinManager>();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            scoreManager.GrabCoin(coinValue);
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
        }
    }



}
