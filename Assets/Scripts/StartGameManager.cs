using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : GameManager
{
    public GameObject exitWarp;
    public override void EnableGame(GameManager parentGame) {
        var item = MetaGameManager.instance.GetHeldItem();
        if(item!=null) {
            if(item == Item.ItemType.Key) {
                announcerText = "Find The Chest!";
            }
            if(item == Item.ItemType.IceKey) {
                announcerText = "Melt the ice!";
            }
            if(item == Item.ItemType.Boots) {
                announcerText = "Wrong boots!";
            }
            if(item == Item.ItemType.DuckBoots) {
                exitWarp.SetActive(true);
                announcerText = "You got the Duck Boots!";
            }
        }
        
        base.EnableGame(parentGame);
    }
}
