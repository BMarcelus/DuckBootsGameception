using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPlayer : PlayerController {
    Item item;
    GameObject plate;

    void Start() {
        item = GetComponentInChildren<Item>();
    }

    public override void OnPrimaryAction() {
        if (item.itemType == Item.ItemType.None) {
            // Try to pick up from floor
            CookingIngredient closest2 = null;
            float closestDist = 9999;
            foreach (var o in transform.parent.GetComponentsInChildren<CookingIngredient>()) {
                float dist = Vector3.Distance(transform.localPosition, o.transform.localPosition);
                if (dist < closestDist) {
                    closestDist = dist;
                    closest2 = o;
                }
            }
            // Check if we are pretty close to that object
            if (closestDist < 1.25f) {
                var i = closest2.GetComponent<CookingIngredient>();
                item.SetItem(i.itemType);
                MetaGameManager.instance.HoldItem(i.itemType);
                Destroy(closest2.gameObject);
            }
            else {
                // Try to pick up from pantry
                Pantry closest = null;
                closestDist = 9999;
                foreach (var o in transform.parent.GetComponentsInChildren<Pantry>()) {
                    float dist = Vector3.Distance(transform.localPosition, o.transform.localPosition);
                    if (dist < closestDist) {
                        closestDist = dist;
                        closest = o;
                    }
                }
                // Check if we are pretty close to that object
                if (closestDist < 1.25f) {
                    var p = closest.GetComponent<Pantry>();
                    item.SetItem(p.ingredient);
                    MetaGameManager.instance.HoldItem(p.ingredient);
                }
            }
        }
        else {
            var c = transform.parent.GetComponentInChildren<CookingController>();
            // Drop it on the plate if we are over the plate and it's the correct item
            if (plate != null) {
                if (c.AdvanceRecipe()) {
                    var obj = Instantiate(
                        MetaGameManager.instance.GetItemVisualPrefab(MetaGameManager.instance.GetHeldItem()),
                        plate.transform.position + new Vector3(0, c.progress*0.3f, 0),
                        plate.transform.rotation,
                        plate.transform);
                    obj.GetComponentInChildren<SpriteRenderer>().sortingOrder = c.progress;
                    item.SetItem(Item.ItemType.None);
                    MetaGameManager.instance.ClearItem();
                }
                else {
                }
            }
            else {
                // Otherwise, drop it on the table
                var itemType = MetaGameManager.instance.GetHeldItem();
                var obj = Instantiate(
                    MetaGameManager.instance.GetItemVisualPrefab(itemType),
                    transform.position - new Vector3(0, 0.75f, 0),
                    transform.rotation,
                    transform.parent);
                obj.AddComponent<CookingIngredient>();
                obj.GetComponent<CookingIngredient>().itemType = itemType;
                item.SetItem(Item.ItemType.None);
                MetaGameManager.instance.ClearItem();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Plate") {
            plate = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Plate") {
            plate = null;
        }
    }
}
