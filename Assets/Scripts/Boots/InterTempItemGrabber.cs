using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InterTempItemGrabber : InterItemGrabber
{
    public GameObject itemVisual;

    public void SetUp(Item.ItemType itemType)
    {
        itemVisual = Instantiate(MetaGameManager.instance.GetItemVisualPrefab(itemType), transform.position, transform.rotation, transform);
        BoxCollider2D bCol = (BoxCollider2D)col;
        bCol.size = Vector2.one;
        itemPickup.itemType = itemType;

    }

    public override void OnInteract(PlayerController pc)
    {
        if (!canInteract) { return; }

        if (pc.HeldItem.itemType != Item.ItemType.None) { return; }

        Debug.Log("Interact 1");

        base.OnInteract(pc);

        Debug.Log("Interact 2");

        Destroy(this.gameObject);
    }
}
