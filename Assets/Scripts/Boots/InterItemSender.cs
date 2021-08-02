using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterItemSender : InteractableObject
{
    public Vector2 directionToSend;

    public override void OnInteract(PlayerController pc)
    {
        if (!canInteract) { return; }

        base.OnInteract(pc);

        if (pc.HeldItem.itemType == Item.ItemType.None) { return; }

        GameObject movingItemGO = new GameObject();
        movingItemGO.transform.parent = this.transform;
        movingItemGO.transform.localPosition = Vector3.zero;
        movingItemGO.AddComponent<MovingItem>();
        MovingItem mi = movingItemGO.GetComponent<MovingItem>();
        Debug.Log("MI: " + mi);
        mi.visualHolder = movingItemGO.transform;
        mi.SetItem(pc.HeldItem);
        mi.Move(directionToSend);
        MetaGameManager.instance.RemoveItem();


    }
}
