using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item.ItemType itemType;
    public void PickUpItem() {
        MetaGameManager.instance.HoldItem(itemType);
    }
}
