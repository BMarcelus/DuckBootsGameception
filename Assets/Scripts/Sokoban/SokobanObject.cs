using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SokobanObject : MonoBehaviour
{
    public enum SokoType {
        Player,
        Crate,
        Wall,
    }
    public SokoType type;
    public Item.ItemType itemType = Item.ItemType.None;

    public int x;
    public int y;

    public enum SokoState {
        Idle,
        Moving,
    }
    public SokoState state = SokoState.Idle;
    public bool pushedOrPulled;
    public Vector3 moveFrom;
    public Vector3 moveTo;
    public float moveT;

    const float moveDuration = 0.2f;

    void Start() {
        moveFrom = transform.localPosition;
        moveTo = transform.localPosition;
    }

    public bool Move(int dx, int dy, bool doPull)
    {
        var sokoManager = SokobanController.instance;
        if (type == SokoType.Wall)  return false;

        /*if (state != SokoState.Idle) {
            Debug.LogWarning("Called Move when in non-idle state");
            return false;
        }*/

        if (dx == 0 && dy == 0) {
            Debug.LogWarning("Called Move with dx=0 dy=0");
            return false;
        }

        pushedOrPulled = false;

        // Check for crate ahead of us and make them move
        int nx = x+dx;
        int ny = y+dy;
        if (!sokoManager.InBounds(nx, ny)) return false;
        var next = sokoManager.objects[nx, ny];
        if (next != null) {
            if (!next.Move(dx, dy, false))  return false;
            pushedOrPulled = true;
        }

        // Actually move
        sokoManager.objects[x,y] = null;
        x += dx;
        y += dy;
        sokoManager.objects[x,y] = this;
        // Set state to moving
        state = SokoState.Moving;
        moveFrom = transform.localPosition;
        moveTo = transform.localPosition + new Vector3(dx, dy, 0)*SokobanController.gridUnitSize;
        moveT = 0;

        // Check for crate behind us that we can pull
        if (doPull) {
            int px = x-dx*2;
            int py = y-dy*2;
            if (sokoManager.InBounds(px, py)) {
                var prev = sokoManager.objects[px, py];
                if (prev != null) {
                    if (prev.Move(dx, dy, false)) {
                        pushedOrPulled = true;
                    }
                }
            }
        }

        return true;
    }

    void Update() {
        if (state == SokoState.Moving) {
            moveT += Time.deltaTime;
            moveT = Mathf.Min(moveT, moveDuration);
            float lerpT = QuadOut(moveT/moveDuration);
            transform.localPosition = Vector3.Lerp(moveFrom, moveTo, lerpT);

            if (moveT == moveDuration) {
                state = SokoState.Idle;
            }
        }
    }

    public static float QuadOut(float k) {
        return k*(2f - k);
    }
}
