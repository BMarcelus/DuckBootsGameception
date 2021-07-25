using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected Collider2D col;

    protected PlayerController pc;

    protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public virtual void OnInteract(PlayerController pc)
    {
        Debug.Log("On Interact!");
    }
}
