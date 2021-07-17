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
    }

    public GameObject GetItemVisualPrefab(Item.ItemType itemType) {
        GameObject visual = itemDataDict[itemType];
        return visual;
    }

    public void SwitchToGame(GameManager game) {
        // currentGame.gameObject.SetActive(false);
        // game.gameObject.SetActive(true);
        game.EnableGame(currentGame);
        currentGame.DisableGame();
        currentGame=game;
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
