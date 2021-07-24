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
            // Find the pantry we are closest to
            Pantry closest = null;
            float closestDist = 9999;
            foreach (var pantry in transform.parent.GetComponentsInChildren<Pantry>()) {
                float dist = Vector3.Distance(transform.localPosition, pantry.transform.localPosition);
                if (dist < closestDist) {
                    closestDist = dist;
                    closest = pantry;
                }
            }

            // Check if we are pretty close to that pantry
            if (closestDist < 1.25f) {
                // Pick up item from that pantry
                Debug.Log(closest.ingredient);
                item.SetItem(Item.ItemType.FakeItem);
            }
        }
        else {
            // Drop it on the plate if we are over the plate and it's the correct item
            if (plate != null) {
                // TODO: Instantiate object here
                Debug.Log("put on plate");

                transform.parent.GetComponentInChildren<CookingController>().AdvanceRecipe();
            }
            else {
                // Otherwise, drop it on the table
                // TODO: Instantiate object here
                Debug.Log("put on table");
            }

            item.SetItem(Item.ItemType.None);
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
