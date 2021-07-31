using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractOnTriggerTag : MonoBehaviour
{
    public string tag;
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == tag) {
            OnTrigger.Invoke();
        }
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
