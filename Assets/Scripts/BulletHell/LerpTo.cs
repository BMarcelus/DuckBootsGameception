using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpTo : MonoBehaviour
{
    public Transform lerper;
    public float lerpValue = 0.2f;
    public float maxTime = 0.5f;
    public UnityEvent OnFinish;
    private float timer;
    private bool lerping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lerping) {
            lerper.position = Vector3.Lerp(lerper.position, transform.position, lerpValue);
            timer += Time.deltaTime;
            if(timer>maxTime) {
                lerping = false;
                OnFinish.Invoke();
            }
        }
    }
    public void StartLerp() {
        lerping = true;
        timer = 0;
    }
}
