using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(AudioSource))]
public class Customer : MonoBehaviour
{
    protected ColorType requestedColor;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;

    public float speed = 3;
    public Vector2 moveDir = Vector2.zero;

    private CustomerSpawner parentSpawner;
    private SpriteRenderer sr;
    private CustomerIndicator ci;

    private AudioSource audioSource;
    private SoundBank sb => SoundBank.Instance;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        ci = GetComponentInChildren<CustomerIndicator>();
        audioSource = GetComponent<AudioSource>();
    }

    protected void Start()
    {
        rb.isKinematic = true;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        col.isTrigger = true;

    }

    protected void Update()
    {
        rb.velocity = moveDir * speed;
    }

    public void SetUp(Vector2 dir, ColorType _requestedColor, CustomerSpawner _parentSpawner)
    {
        moveDir = dir.normalized;
        requestedColor = _requestedColor;
        parentSpawner = _parentSpawner;
        ci.SetColor(_requestedColor);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Item colItem = collision.GetComponent<Item>();
        if (colItem)
        {
            if (colItem.itemType == Item.ItemType.Boots && requestedColor == colItem.GetColor())
            {
                ReceivedItem(true);
            }
            else
            {
                ReceivedItem(false);
            }

            Destroy(colItem.gameObject);
        }

        InterItemSender colIIS = collision.GetComponent<InterItemSender>();
        if (colIIS)
        {
            ReceivedItem(false);
        }
    }

    public void ReceivedItem(bool isSatisfied)
    {
        if (isSatisfied)
        {
            audioSource.PlayOneShot(sb.GetAudioClip(SoundType.CustomerHappy));
        }
        else
        {
            audioSource.PlayOneShot(sb.GetAudioClip(SoundType.CustomerSad));
        }

        ci.SetSatisfaction(isSatisfied);
        col.enabled = false;
        parentSpawner.RemoveCustomer(this, isSatisfied);
        rb.velocity = Vector3.zero;
    }
}
