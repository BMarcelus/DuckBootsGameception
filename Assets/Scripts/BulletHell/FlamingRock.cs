using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingRock : MonoBehaviour
{
    private void Explode () {
        Destroy(this.gameObject);
    }
    private void OnDisable() {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "FlamingRock") return;
        if (other.gameObject.tag == "Wall") return;

        this.Explode();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        this.Explode();
        
    }
}
