using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    private GameManager parentGame;

    public void EnableGame(GameManager parentGame) {
        player.SetActive(true);
        this.parentGame = parentGame; // for going backwards
    }
    public void DisableGame() {
        player.SetActive(false);
    }
    public void Retract() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
