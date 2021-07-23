using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSokobanMovement : PlayerMovement
{
    SokobanObject sokoObj;
    SpriteRenderer sprite;
    public Sprite front;
    public Sprite front2;
    public Sprite back;
    public Sprite back2;

    protected override void Start()
    {
        base.Start();
        sokoObj = GetComponent<SokobanObject>();
        sprite = GetComponentInChildren<SpriteRenderer>();
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

            sokoObj.Move(dx, dy, true);

            // Update sprite
            if (dx < 0)  sprite.flipX = false;
            if (dx > 0)  sprite.flipX = true;
            if (dy < 0)  sprite.sprite = front;
            if (dy > 0)  sprite.sprite = back;
            if (sokoObj.pushedOrPulled) {
                if (sprite.sprite == front)  sprite.sprite = front2;
                if (sprite.sprite == back)  sprite.sprite = back2;
            }
            else {
                if (sprite.sprite == front2)  sprite.sprite = front;
                if (sprite.sprite == back2)  sprite.sprite = back;
            }
        }
    }
}
