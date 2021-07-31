using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverObjectController : MonoBehaviour
{
    protected RiverMovement npcMovement;

    Coroutine movingCoroutine = null;

    public virtual void Awake()
    {
        npcMovement = GetComponent<RiverMovement>();
    }

    private void OnEnable()
    {
        StartMoving();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetMovement(Vector2 movementDirection)
    {

        if (movementDirection == Vector2.zero)
        {
            npcMovement.StopMoving();
        }
        else
        {
            npcMovement.Move(movementDirection);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        npcMovement.SetDirection(direction);
    }

    public Vector2 GetFacingDirection()
    {
        Vector2 moveDir = npcMovement.movementDirection.normalized;

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

    IEnumerator Move()
    {
        while (true)
        {
            Random.InitState((int)System.DateTime.Now.Ticks + this.GetInstanceID());
            float randomWait = Random.Range(0.05f, 0.5f);
            yield return new WaitForSeconds(randomWait);

            Vector2 randomDir;

            bool isMove = (Random.value < 0.8f);
            if (isMove)
            {
                randomDir = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.5f, 0f));

            }
            else
            {
                randomDir = Vector2.zero;
            }
            randomDir = randomDir + (Vector2.down * 0.1f);
            randomDir.Normalize();

            SetMovement(randomDir);
        }
    }



    void StartMoving()
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
            movingCoroutine = null;
        }

        movingCoroutine = StartCoroutine(Move());
    }
}
