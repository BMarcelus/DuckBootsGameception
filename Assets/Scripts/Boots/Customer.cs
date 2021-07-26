using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]
public class Customer : MonoBehaviour
{
    protected ColorType requestedColor;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;

    public float speed = 3;
    public Vector2 moveDir = Vector2.zero;

    private CustomerSpawner parentSpawner;
    private SpriteRenderer sr;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
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
        }

        InterItemSender colIIS = collision.GetComponent<InterItemSender>();
        if (colIIS)
        {
            Debug.Log("You lose!");
        }
    }

    public void ReceivedItem(bool isSatisfied)
    {
        if (isSatisfied)
        {
            sr.color = Color.green;
            Debug.Log("I'm happy!");
        }
        else
        {
            sr.color = Color.red;
            Debug.Log("I'm Angry!");
        }

        col.enabled = false;
        parentSpawner.RemoveCustomer(this);
    }
}
