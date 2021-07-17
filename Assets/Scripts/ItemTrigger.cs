using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTrigger : MonoBehaviour
{
    public Item.ItemType itemType;
    public UnityEvent OnTriggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Item item = other.GetComponentInChildren<Item>();
        if(item==null)return;
        if(item.itemType == itemType) {
            OnTriggered.Invoke();
        }
        item.Triggered(gameObject);
    }
}
