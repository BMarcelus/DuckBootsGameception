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

    public int x;
    public int y;

    public enum SokoState {
        Idle,
        Moving,
    }
    public SokoState state = SokoState.Idle;
    Vector3 moveFrom;
    Vector3 moveTo;
    float moveT;

    const float moveDuration = 0.2f;

    public SokobanController sokoManager;

    void Start() {
    }

    public bool Move(int dx, int dy)
    {
        if (state != SokoState.Idle) {
            //Debug.LogWarning("Called Move when in non-idle state");
            return false;
        }

        if (dx == 0 && dy == 0) {
            Debug.LogWarning("Called Move with dx=0 dy=0");
            return false;
        }

        // Check for crate ahead of us and make them move
        int nx = x+dx;
        int ny = y+dy;
        if (nx < 0 || nx > sokoManager.objects.GetLength(0) || ny < 0 || ny > sokoManager.objects.GetLength(1))  return false;
        var next = sokoManager.objects[nx, ny];
        if (next != null) {
            if (next.type == SokoType.Wall)  return false;
            var success = next.Move(dx, dy);
            if (!success) return false;
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
