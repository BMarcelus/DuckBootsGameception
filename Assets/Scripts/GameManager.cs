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

    // Start is called before the first frame update
    void Start()
    {
        if(this!=MetaGameManager.instance.currentGame) activeObjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
