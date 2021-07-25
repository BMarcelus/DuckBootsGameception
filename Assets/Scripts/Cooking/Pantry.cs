using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantry : MonoBehaviour {
    public Item.ItemType ingredient;
    void Start() {
        foreach (Transform child in transform) {
            if (child.gameObject.name.StartsWith("Sprite")) {
                Instantiate(MetaGameManager.instance.GetItemVisualPrefab(ingredient), child.position, child.rotation, transform);
                Destroy(child.gameObject);
            }
        }
    }
}
