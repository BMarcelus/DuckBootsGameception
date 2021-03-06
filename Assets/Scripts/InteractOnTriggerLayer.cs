using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractOnTriggerLayer : MonoBehaviour
{
    public LayerMask layermask;
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D other) {
        if((layermask.value& 1<<other.gameObject.layer)!=0) {
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
