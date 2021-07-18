using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjects;
    public Item heldItemSprite;
    private GameManager parentGame = null;

    public void EnableGame(GameManager parentGame) {
        activeObjects.SetActive(true);
        if(heldItemSprite!=null) {
            heldItemSprite.SetItem(MetaGameManager.instance.GetHeldItem());
        }
        if(this.parentGame==null)
        this.parentGame = parentGame; // for going backwards
    }
    public void DisableGame() {
        activeObjects.SetActive(false);
    }
    public void Retract() {

    }

    public void SetHeldItem(Item.ItemType itemType, GameObject visualPrefab) {
        heldItemSprite.SetItem(itemType, visualPrefab);
    }

    void Awake()
    {
        // if(this!=MetaGameManager.instance.currentGame)
        activeObjects.SetActive(false);
    }

    void Update()
    {
        
    }
}
