using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    protected PlayerMovement pMove;
    protected PlayerAnimatable pAni;
    protected PlayerInput pInput;

    protected Item heldItem;
    public Item HeldItem => heldItem;

    public virtual void Awake()
    {
        pMove = GetComponent<PlayerMovement>();
        pAni = GetComponent<PlayerAnimatable>();
        pInput = GetComponent<PlayerInput>();
        heldItem = GetComponentInChildren<Item>();
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
            pAni?.PlayAnimation("Idle");
        }
        else
        {
            pMove.Move(movementDirection);
            pAni?.SetAniDirection(movementDirection);
            pAni?.PlayAnimation("Movement");
        }
    }

    public void SetDirection(Vector2 direction)
    {
        pMove.SetDirection(direction);
        pAni?.SetAniDirection(direction);
    }

    public Vector2 GetFacingDirection()
    {
        Vector2 moveDir = pMove.movementDirection.normalized;

        if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
        {
            if (moveDir.x > 0)
            {
                return Vector2.right;
            }
            else
            {
                return Vector2.left;
            }
        }
        else
        {
            if (moveDir.y > 0)
            {
                return Vector2.up;
            }
            else
            {
                return Vector2.down;
            }
        }
    }

    public virtual void SetCanInput(bool _canInput)
    {
        pInput.SetCanInput(_canInput);
    }
}
