using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemPickup))]
public class InterItemGrabber : InteractableObject
{
    ItemPickup itemPickup;

    protected override void Awake()
    {
        base.Awake();
        itemPickup = GetComponent<ItemPickup>();
    }

    public override void OnInteract(PlayerController pc)
    {
        Debug.Log("OnInteract");
        itemPickup.PickUpItem();
    }
}
