using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneTransitionController : MonoBehaviour
{
    public GameObject StartScene;
    public GameObject EndScene;

    public UnityEvent StartSceneTransition;
    public UnityEvent EndSceneTransition;
    public UnityEvent BeforeSceneUnload;
    public UnityEvent AfterSceneLoad;

    public enum GAMES {
        HOOK
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeAndLoadScene(GAMES game, GameObject spawnPoint) {

    }
}
