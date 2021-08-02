using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractableObject : MonoBehaviour
{
    protected Collider2D col;

    protected PlayerController pc;

    protected bool canInteract = true;

    protected AudioSource audioSource;
    protected SoundBank sb => SoundBank.Instance;
    public SoundType soundMade;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    protected void PlayInteractSound()
    {
        if (soundMade != 0)
            audioSource.PlayOneShot(sb.GetAudioClip(soundMade));
    }
}
