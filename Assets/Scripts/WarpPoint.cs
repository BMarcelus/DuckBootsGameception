using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public GameManager game;
    private void OnTriggerEnter2D(Collider2D other) {
        MetaGameManager.instance.SwitchToGame(game);
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
