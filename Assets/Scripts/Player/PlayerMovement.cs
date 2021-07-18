using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Vector3 movementDirection;

    protected Rigidbody2D body;

    private void OnDisable() {
        StopMoving();
    }

    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    public virtual void Move(Vector3 newDirection)
    {
        SetDirection(newDirection);
    }

    public virtual void StopMoving()
    {
        body.velocity = Vector2.zero;
    }

    public void SetDirection(Vector3 newDirection)
    {
        movementDirection = newDirection;
    }
}
