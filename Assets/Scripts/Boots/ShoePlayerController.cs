using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePlayerController : PlayerController
{
    protected Vector2 colSize;
    protected Collider2D col;

    public override void Awake()
    {
        base.Awake();
        col = GetComponent<Collider2D>();
    }

    public override void OnPrimaryAction()
    {


        bool interacted = OnInteract();

        if (!interacted && heldItem.itemType != Item.ItemType.None)
        {
            DropItem(heldItem.itemType);
        }
    }

    private void DropItem(Item.ItemType itemToDrop)
    {
        var obj = Instantiate(new GameObject(), transform.position, transform.rotation, MetaGameManager.instance.currentGame.activeObjects.transform);
        obj.AddComponent<InterTempItemGrabber>();
        InterTempItemGrabber itig = obj.GetComponent<InterTempItemGrabber>();
        itig.SetUp(itemToDrop);
        MetaGameManager.instance.RemoveItem();
    }

    public bool OnInteract()
    {
        InteractableObject[] usableInteractables = FindUsableInteractables();

        if (usableInteractables == null)
        {
            return false;
        }


        foreach (InteractableObject inter in usableInteractables)
        {
            inter.OnInteract(this);
        }

        return true;
    }

    protected virtual InteractableObject[] FindUsableInteractables()
    {

        Collider2D[] closeColliders = GetCloseColliders();

        InteractableObject[] closestInteractables = null;
        float angleToClosestInteractable = Mathf.Infinity;

        for (int i = 0; i < closeColliders.Length; i++)
        {
            InteractableObject[] colliderInteractable = closeColliders[i].GetComponents<InteractableObject>();

            InteractableObject interColliderTest = closeColliders[i].GetComponent<InteractableObject>();

            if (interColliderTest == null)
            {
                continue;
            }

            Vector3 directionToInteractable = closeColliders[i].transform.position - transform.position;
            float angleToInteractable = Vector3.Angle(GetFacingDirection(), directionToInteractable);

            if (angleToInteractable < 90)
            {
                if (angleToInteractable < angleToClosestInteractable)
                {
                    closestInteractables = colliderInteractable;

                    angleToClosestInteractable = angleToInteractable;
                }
            }
        }

        return closestInteractables;
    }

    void GetColSize()
    {
        colSize = Vector2.one;

        if (GetComponent<BoxCollider2D>())
        {
            BoxCollider2D _col = GetComponent<BoxCollider2D>();
            colSize = new Vector2(_col.size.x + _col.edgeRadius, _col.size.y + _col.edgeRadius);
        }

        if (GetComponent<CircleCollider2D>())
        {
            CircleCollider2D _col = GetComponent<CircleCollider2D>();
            colSize = new Vector2(_col.radius * 2, _col.radius * 2);
        }
    }

    public Collider2D[] GetCloseColliders()
    {
        GetColSize();

        return Physics2D.OverlapAreaAll((Vector2)transform.position + col.offset + colSize * .6f, (Vector2)transform.position + col.offset - colSize * .6f);
    }
}
