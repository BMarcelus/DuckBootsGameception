using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaGameManager : MonoBehaviour
{
    public static MetaGameManager instance;

    private GameManager currentGame;
    private Item.ItemType heldItem;

    void Start()
    {
        instance = this;
    }

    public void SwitchToGame(GameManager game) {
        
    }

    public void HoldItem(Item.ItemType itemType) {
        heldItem = itemType;
    }

    public void ClearItem() {
        heldItem = Item.ItemType.None;
    }

    void Update()
    {
        
    }
}
