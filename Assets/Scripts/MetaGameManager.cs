using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaGameManager : MonoBehaviour
{
    public static MetaGameManager instance;
    [System.Serializable]
    public class ItemData {
        public Item.ItemType itemType;
        public GameObject visual;
    }
    public ItemData[] itemDatas;
    private Dictionary<Item.ItemType, GameObject> itemDataDict;


    public GameManager currentGame;
    private Item.ItemType heldItem;

    void Start()
    {
        instance = this;
        itemDataDict = new Dictionary<Item.ItemType, GameObject>();
        foreach(ItemData itemData in itemDatas) {
            itemDataDict.Add(itemData.itemType, itemData.visual);
        }
        currentGame.EnableGame(null);
    }

    public GameObject GetItemVisualPrefab(Item.ItemType itemType) {
        GameObject visual = itemDataDict[itemType];
        return visual;
    }

    public void SwitchToGame(GameManager game) {
        // currentGame.gameObject.SetActive(false);
        // game.gameObject.SetActive(true);
        currentGame.DisableGame();
        game.EnableGame(currentGame);
        currentGame=game;
    }

    public void HoldItem(Item.ItemType itemType) {
        heldItem = itemType;
        currentGame.SetHeldItem(itemType, GetItemVisualPrefab(itemType));
    }

    public void ClearItem() {
        heldItem = Item.ItemType.None;
    }
    
    public Item.ItemType GetHeldItem() {
        return heldItem;
    }

    void Update()
    {
        
    }
}
