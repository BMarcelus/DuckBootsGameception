using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAfterSeconds : MonoBehaviour
{
    public float seconds;
    public UnityEvent eventToCall;
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("TriggerEvent", seconds);
    }
    public void TriggerEvent() {
        if(!this.enabled)return;
        if(!gameObject.activeInHierarchy)return;
        eventToCall.Invoke();
    }
    private void OnEnable() {
        Invoke("TriggerEvent", seconds);
    }
}
