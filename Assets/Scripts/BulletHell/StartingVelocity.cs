using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingVelocity : MonoBehaviour
{
    public float forwardVelocity;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * forwardVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
