using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class MovingItem : Item
{
    protected Rigidbody2D rb;
    protected BoxCollider2D col;

    public float speed = 3;
    public Vector2 moveDir = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        rb.isKinematic = true;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        col.isTrigger = true;
        StartCoroutine(DestoryAfter5Seconds());
    }

    protected void OnDisable()
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    protected override void Update()
    {
        rb.velocity = moveDir * speed;
    }

    public void Move(Vector2 dir)
    {
        moveDir = dir.normalized;
    }

    private IEnumerator DestoryAfter5Seconds()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
