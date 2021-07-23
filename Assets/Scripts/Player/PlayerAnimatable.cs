using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatable : BaseAnimatable
{
    protected PlayerMovement pMove;
    protected PlayerController pController;

    protected override void Awake()
    {
        base.Awake();
        pMove = GetComponent<PlayerMovement>();
        pController = GetComponent<PlayerController>();
    }
}
