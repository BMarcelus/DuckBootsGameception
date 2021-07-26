using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawn : MonoBehaviour
{
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.Respawn();
    }

    private void Respawn() {
        this.transform.position = spawnPoint.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag != "FlamingRock") return;

        this.Respawn();
    }
}
