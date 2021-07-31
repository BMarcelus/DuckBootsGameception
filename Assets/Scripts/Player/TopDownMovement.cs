using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : PlayerMovement
{
    public float BASE_MOVEMENT_SPEED = 9f;
    public float speed;

    protected float DIAGONAL_SLOW_DOWN = 1.0f;
    protected override void Start()
    {
        base.Start();
        body.gravityScale = 0;
        body.freezeRotation = true;
        ResetSpeed();
    }

    public override void Move(Vector3 newDirection)
    {
        base.Move(newDirection);
        //This is needed to slow down diagonal movement

        if (movementDirection.x != 0 && movementDirection.y != 0)
            DIAGONAL_SLOW_DOWN = 0.707f;

        //Apply movement to character
        body.velocity = movementDirection * speed * DIAGONAL_SLOW_DOWN;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void ResetSpeed()
    {
        speed = BASE_MOVEMENT_SPEED;
    }
}
