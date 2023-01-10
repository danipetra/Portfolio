using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : Platform
{
    [Range(1f,4f)]
    public float playerSpeedMuliplier = 1.3f;

    private  Player player;
    private float defaultPlayerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            increasePlayerVelocity();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            resetPlayerVelocity();
        }
    }

    void increasePlayerVelocity()
    {
        defaultPlayerSpeed = player.moveSpeed;
        player.moveSpeed *= playerSpeedMuliplier;
    }

    private void resetPlayerVelocity()
    {
        player.moveSpeed = defaultPlayerSpeed;
    }
}
