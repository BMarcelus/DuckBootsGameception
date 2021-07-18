using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSokobanMovement : PlayerMovement
{
    SokobanObject sokoObj;

    protected override void Start()
    {
        base.Start();
        sokoObj = GetComponent<SokobanObject>();
    }

    public override void Move(Vector3 newDirection)
    {
        if (sokoObj.state == SokobanObject.SokoState.Idle) {
            var dx = (int)Mathf.Round(newDirection.x);
            var dy = (int)Mathf.Round(newDirection.y);

            // If holding diagonal
            if (dx != 0 && dy != 0) {
                dy = 0;
            }

            sokoObj.Move(dx, dy);
        }
    }
}
