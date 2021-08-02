using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource)), RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]
public class ItemSwapObject : MonoBehaviour
{
    public Item.ItemType itemRequest;
    public Item.ItemType itemToTrade;

    private AudioSource audioSource;
    private SoundBank sb => SoundBank.Instance;

    public Sprite notReceivedSprite;
    public Sprite receivedSprite;
    public Sprite itemSprite;

    private SpriteRenderer sr;

    private ItemIndicator itemIndicator;

    public bool isOpened = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponentInChildren<SpriteRenderer>();
        itemIndicator = GetComponentInChildren<ItemIndicator>();
    }

    private void OnEnable()
    {
        ResetItemIndicator();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpened) { return; }

        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc)
        {
            if (pc.HeldItem != null && pc.HeldItem.itemType != Item.ItemType.None)
            {
                Item.ItemType incomingItem = pc.HeldItem.itemType;

                if (incomingItem == itemRequest)
                {
                    SwapItem();
                }
            }
        }
    }

    private void SwapItem()
    {
        MetaGameManager.instance.HoldItem(itemToTrade);
        sr.sprite = receivedSprite;
        itemIndicator.Hide();
        isOpened = true;
    }

    private void ResetItemIndicator()
    {
        itemIndicator.gameObject.SetActive(true);
        sr.sprite = notReceivedSprite;
        itemIndicator.Show(itemSprite);
        isOpened = false;
    }
}
