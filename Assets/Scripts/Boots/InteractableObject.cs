using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected Collider2D col;

    protected PlayerController pc;

    protected bool canInteract = true;

    protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
    }


    public virtual void OnInteract(PlayerController pc)
    {
        if (!canInteract) { return; }
        StartCoroutine(tempDisableOnInteract());
    }

    IEnumerator tempDisableOnInteract()
    {
        canInteract = false;
        yield return new WaitForSeconds(.5f);
        canInteract = true;
    }
}
