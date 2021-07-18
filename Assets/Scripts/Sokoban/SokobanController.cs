using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SokobanController : MonoBehaviour
{
    public SokobanObject[,] objects = new SokobanObject[100,100];
    public const float gridUnitSize = 1f;

    void Awake()
    {
        // Assign all objects to their space in the grid
        foreach (Transform child in transform) {
            var sokoObj = child.gameObject.GetComponent<SokobanObject>();
            if (sokoObj != null) {
                child.localPosition = new Vector3(
                    Mathf.Round(child.localPosition.x),
                    Mathf.Round(child.localPosition.y),
                    child.localPosition.z);

                int x = (int)(child.localPosition.x)+50;
                int y = (int)(child.localPosition.y)+50;
                //Debug.Log(x);
                //Debug.Log(y);

                sokoObj.x = x;
                sokoObj.y = y;
                sokoObj.sokoManager = this;
                objects[x, y] = sokoObj;
            }
        }
    }
}
