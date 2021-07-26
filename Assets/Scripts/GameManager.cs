using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjects;
    protected Item heldItemSprite;
    private GameManager parentGame = null;

    private PlayerController pc;

    public virtual void EnableGame(GameManager parentGame) {
        activeObjects.SetActive(true);
        heldItemSprite = pc.HeldItem;

        if (heldItemSprite!=null) {
            heldItemSprite.SetItem(MetaGameManager.instance.GetHeldItem());
        }
        if(this.parentGame==null)
        this.parentGame = parentGame; // for going backwards
    }
    public virtual void DisableGame() {
        activeObjects.SetActive(false);
    }
    public void Retract() {

    }

    public void SetHeldItem(Item.ItemType itemType, GameObject visualPrefab) {
        heldItemSprite.SetItem(itemType, visualPrefab);
    }

    void Awake()
    {
        pc = GetComponentInChildren<PlayerController>();

        activeObjects.SetActive(false);
    }

    private void Start()
    {

    }

    void Update()
    {
        
    }
}
