using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColliderChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //disable rigidbody
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //set initial position to current position
            GetComponent<Button>().originalPosition = transform.position;
            GetComponent<Button>().minYpos = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
    }
}
