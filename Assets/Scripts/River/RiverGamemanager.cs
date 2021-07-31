using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGamemanager : GameManager
{
    protected WaterfallWarp[] waterfallWarps;
    public WaterfallWarp[] WaterfallWarps => waterfallWarps;

    protected override void Awake()
    {
        waterfallWarps = GetComponentsInChildren<WaterfallWarp>();
        base.Awake();
    }
}
