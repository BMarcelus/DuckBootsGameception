using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundBank : MonoBehaviour
{
    [SerializeField]
    private SoundInfo[] sInfo;

    private Dictionary<SoundType, AudioClip> sDict = new Dictionary<SoundType, AudioClip>();

    private static SoundBank instance;
    public static SoundBank Instance
    {
        get {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundBank>();
            }
            return instance;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }

        foreach(SoundInfo si in sInfo)
        {
            if (sDict.ContainsKey(si.key))
            {
                Debug.LogError("The key " + si.key + " is repeated in the sound bank!");
                continue;
            }

            sDict.Add(si.key, si.sound);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType sType)
    {
        if (!sDict.ContainsKey(sType)) { return; }

        if (sType == SoundType.None) { return; }

        audioSource.PlayOneShot(sDict[sType]);
    }

    public AudioClip GetAudioClip(SoundType sType)
    {
        if (!sDict.ContainsKey(sType)) { return null; }

        if (sType == SoundType.None) { return null; }

        return sDict[sType];
    }
}

[System.Serializable]
public struct SoundInfo
{
    public AudioClip sound;
    public SoundType key;
}

public enum SoundType
{
    None,
    Success,
    Failure,
    CustomerHappy,
    CustomerSad,
    SendItem,
    GrabItem,
    Teleport,
    TextBeep,
    PaintItem,
    EnemyShoot,
    Explosion,
}
