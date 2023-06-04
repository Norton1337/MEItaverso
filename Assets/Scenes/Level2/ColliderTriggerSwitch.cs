using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerSwitch : MonoBehaviour
{
    private Collider2D coll;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            coll.isTrigger = true;
        }
    }
}
