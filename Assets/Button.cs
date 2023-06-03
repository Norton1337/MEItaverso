using UnityEngine;

public class Button : MonoBehaviour
{
    public Vector3 originalPosition;
    private bool moveBack = false;
    public bool isPressed = false;
    public Vector2 minYpos = new Vector2(0, 0);

    private void Start()
    {
        originalPosition = transform.position;
        minYpos = new Vector2(transform.position.x, transform.position.y - 0.5f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && transform.position.y > minYpos.y)
        {
            Vector2 contactNormal = collision.GetContact(0).normal;
            if (contactNormal.x == 0) {
                transform.Translate(0, -0.03f, 0);
                moveBack = false;
                Debug.Log("Player is on the button");
                isPressed = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = null;
            moveBack = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("Player left the button");
            isPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = transform;
            GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Player touched the button");
        }
    }

    private void Update()
    {
        if (moveBack)
        {
            if (transform.position.y < originalPosition.y)
            {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
