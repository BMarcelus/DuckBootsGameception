using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    protected PlayerMovement pMove;
    protected PlayerAnimatable pAni;
    protected PlayerInput pInput;

    public virtual void Awake()
    {
        pMove = GetComponent<PlayerMovement>();
        pAni = GetComponent<PlayerAnimatable>();
        pInput = GetComponent<PlayerInput>();
    }

    public virtual void OnPrimaryAction()
    {

    }

    public virtual void OnSecondaryAction()
    {

    }

    public void SetMovement(Vector2 movementDirection)
    {

        if (movementDirection == Vector2.zero)
        {
            pMove.StopMoving();
            pAni.PlayAnimation("Idle");
        }
        else
        {
            pMove.Move(movementDirection);
            pAni.SetAniDirection(movementDirection);
            pAni.PlayAnimation("Movement");
        }
    }

    public void SetDirection(Vector2 direction)
    {
        pMove.SetDirection(direction);
        pAni.SetAniDirection(direction);
    }

    public virtual void SetCanInput(bool _canInput)
    {
        pInput.SetCanInput(_canInput);
    }
}
