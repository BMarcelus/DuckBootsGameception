using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    public SoundType soundType;
    private AudioSource audioSource;
    SoundBank sb => SoundBank.Instance;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound() {
        audioSource.PlayOneShot(sb.GetAudioClip(soundType));
    }
}
