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
    public GameManager prevGame;

    public bool debugLogs = false;

    private Item.ItemType heldItem;

    private SceneTransitionController stc => SceneTransitionController.Instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        itemDataDict = new Dictionary<Item.ItemType, GameObject>();
        foreach(ItemData itemData in itemDatas) {
            itemDataDict.Add(itemData.itemType, itemData.visual);
        }

        SwitchToGame(currentGame);
    }

    public GameObject GetItemVisualPrefab(Item.ItemType itemType) {

        if (itemType == Item.ItemType.None)
            return null;

        GameObject visual = itemDataDict[itemType];
        return visual;
    }

    public void SwitchToGame(GameManager game)
    {
        if (stc.IsFading) { return; }

        prevGame = currentGame;
        currentGame = game;

        stc.OnGameUnload += DeloadGame;
        stc.OnGameLoad += LoadGame;
        stc.FadeAndLoadGame();
    }

    private void DeloadGame()
    {
        stc.OnGameUnload -= DeloadGame;
        if(debugLogs)
            Debug.Log("Disabling " + prevGame.gameObject.name);
        prevGame.DisableGame();
    }

    private void LoadGame()
    {
        stc.OnGameLoad -= LoadGame;
        if(debugLogs)
            Debug.Log("Enabling " + currentGame.gameObject.name);
        currentGame.EnableGame(prevGame);
    }

    public void HoldItem(Item.ItemType itemType) {
        SoundBank.Instance.PlaySound(SoundType.GrabItem);
        heldItem = itemType;
        currentGame.SetHeldItem(itemType, GetItemVisualPrefab(itemType));
    }

    public void ClearItem() {
        heldItem = Item.ItemType.None;
    }

    public void RemoveItem()
    {
        ClearItem();
        currentGame.SetHeldItem(Item.ItemType.None, null);
    }
    
    public Item.ItemType GetHeldItem() {
        return heldItem;
    }

    void Update()
    {
        
    }
}
