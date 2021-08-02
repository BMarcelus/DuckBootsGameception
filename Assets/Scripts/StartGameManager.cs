using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : GameManager
{
    public GameObject exitWarp;
    public override void EnableGame(GameManager parentGame) {
        var item = MetaGameManager.instance.GetHeldItem();

        base.EnableGame(parentGame);

        if(item != null && item == Item.ItemType.Key) {
            exitWarp.SetActive(true);
            announcerText = "You got the Duck Boots!";
        }
    }
}
