using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {
        None,
        FakeItem,
    }
    public ItemType itemType;
    public Transform visualHolder;
    public void SetItem(Item.ItemType itemType) {
        this.itemType = itemType;
        GameObject visualPrefab = MetaGameManager.instance.GetItemVisualPrefab(itemType);
        foreach (Transform child in visualHolder) {
            GameObject.Destroy(child.gameObject);
        }
        if(visualPrefab==null)return;       
        GameObject visual = Instantiate(visualPrefab, visualHolder.position, visualHolder.rotation);
        visual.transform.parent = visualHolder;
    }

    public void SetItem(Item.ItemType itemType, GameObject visualPrefab) {
        this.itemType = itemType;
        foreach (Transform child in visualHolder) {
            GameObject.Destroy(child.gameObject);
        }
        if(visualPrefab==null)return;       
        GameObject visual = Instantiate(visualPrefab, visualHolder.position, visualHolder.rotation);
        visual.transform.parent = visualHolder;
    }

    virtual public void Triggered(GameObject gameObject) {

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
