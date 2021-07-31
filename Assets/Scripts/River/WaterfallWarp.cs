using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WaterfallWarp : MonoBehaviour
{
    public Vector2 facingDir = Vector2.zero;

    private RiverGamemanager rgm;

    private void Awake()
    {
        rgm = GetComponentInParent<RiverGamemanager>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (WaterfallWarp ww in rgm.WaterfallWarps)
        {
            if (ww.GetInstanceID() != this.GetInstanceID())
            {
                Debug.Log("Something entered WW!");
                float yPos = ww.transform.position.y + ww.facingDir.y;
                collision.transform.position = new Vector3(collision.transform.position.x, yPos, collision.transform.position.z);
            }
        }
    }
}
