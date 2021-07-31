using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverMovement : TopDownMovement
{
    public override void Move(Vector3 newDirection)
    {
        base.Move(newDirection);

        if (newDirection.y > 0)
        {
            SetSpeed(BASE_MOVEMENT_SPEED - 2);
        }
        else if(newDirection.y < 0)
        {
            SetSpeed(BASE_MOVEMENT_SPEED + 1);
        }
        else
        {
            ResetSpeed();
        }
        //Apply movement to character
        body.velocity = movementDirection * speed * DIAGONAL_SLOW_DOWN;
    }
}
