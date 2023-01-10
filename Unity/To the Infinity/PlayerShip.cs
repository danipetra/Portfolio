using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public FloatingJoystick directionJoystick;

    private Vector2 direction;

    void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        setDirection();
    }


    private void setDirection()
    {
        direction = directionJoystick.Direction;

        turn(direction);
    }

        

}
