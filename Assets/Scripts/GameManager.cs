using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject activeObjects;
    protected Item heldItemSprite;
    private GameManager parentGame = null;

    private PlayerController pc;

    public WarpPoint entryWarp;
    public WarpPoint[] exitWarps;

    public virtual void EnableGame(GameManager parentGame)
    {
        activeObjects.SetActive(true);
        heldItemSprite = pc.HeldItem;

        if (heldItemSprite!=null) {
            heldItemSprite.SetItem(MetaGameManager.instance.GetHeldItem());
        }
        if(this.parentGame==null)
        this.parentGame = parentGame; // for going backwards
    }

    public virtual void DisableGame()
    {
        activeObjects.SetActive(false);
    }
    public virtual void Retract()
    {

    }

    public void SetHeldItem(Item.ItemType itemType, GameObject visualPrefab)
    {
        heldItemSprite.SetItem(itemType, visualPrefab);
    }

    protected virtual void Awake()
    {
        pc = GetComponentInChildren<PlayerController>();

        activeObjects.SetActive(false);
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        
    }

    protected void ReturnPlayerToEntry()
    {
        if (entryWarp == null) { return; }

        pc.transform.position = entryWarp.transform.position + (Vector3)entryWarp.facingDir.normalized * 2;
    }

    protected void EnableExitWarps(bool isEnabled)
    {
        if (exitWarps == null || exitWarps.Length == 0) { return; }

        foreach (WarpPoint w in exitWarps)
        {
            w.gameObject.SetActive(isEnabled);
        }
    }
}
