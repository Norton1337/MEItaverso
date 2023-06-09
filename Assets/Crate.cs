using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        collision.gameObject.GetComponent<PlayerController>().deadBodyActive)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        collision.gameObject.GetComponent<PlayerController>().deadBodyActive)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.gameObject.CompareTag("Player") &&
        !collision.gameObject.GetComponent<PlayerController>().deadBodyActive)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        collision.gameObject.GetComponent<PlayerController>().deadBodyActive)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (collision.gameObject.CompareTag("Player") &&
        !collision.gameObject.GetComponent<PlayerController>().deadBodyActive)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}

