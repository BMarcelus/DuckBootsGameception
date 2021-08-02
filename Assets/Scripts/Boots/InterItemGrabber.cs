using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemPickup))]
public class InterItemGrabber : InteractableObject
{
    protected ItemPickup itemPickup;

    protected override void Awake()
    {
        base.Awake();
        itemPickup = GetComponent<ItemPickup>();
    }

    public override void OnInteract(PlayerController pc)
    {
        if (!canInteract) { return; }

        if (pc.HeldItem.itemType != Item.ItemType.None) { return; }

        base.OnInteract(pc);
 
        itemPickup.PickUpItem();
    }
}
