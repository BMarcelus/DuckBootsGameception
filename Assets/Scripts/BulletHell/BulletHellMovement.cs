using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellMovement : PlayerMovement
{
    public float horizontalForce = 10f;
    public float verticalUpForce = 4f;
    public float verticalDownForce = 10f;


    protected override void Start() {
        base.Start();
        body.freezeRotation = true;
    }

    public override void StopMoving() {
        // let physics do its thing
    }
    public override void Move(Vector3 newDirection)
    {
        Vector3 normVec = newDirection.normalized;
        Vector2 calcVel = new Vector2(normVec.x * horizontalForce, normVec.y * (normVec.y >= 0 ? verticalUpForce : verticalDownForce));

        body.AddForce(calcVel - body.velocity);
    }
}
