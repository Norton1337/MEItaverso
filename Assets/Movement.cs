using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 20f;
    public GameObject aimTriangle;
    private float Move;
    public Transform aimPivot;
    private Rigidbody2D rb;
    private Quaternion initialRotation;
    private bool inCannon;
    public Vector3 aimDirection;

    public bool isLaunched = false;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialRotation = aimTriangle.transform.rotation;
    }

    void Update()
    {
        isLaunched = GameManager.Instance.playerLaunched;
        // get is player in cannon from GameManager
        inCannon = GameManager.Instance.playerInCannon;
        

        if(!inCannon && !isLaunched)
        {
            Move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(Move * speed, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
        
      

        if (isLaunched)
        {
            if(Mathf.Abs(rb.velocity.x) < 0.001f && Mathf.Abs(rb.velocity.y) < 0.001f){
                GameManager.Instance.playerLaunched = false;
            }
                
        }
        

        GetAimDirection();

        // Calculate the rotation angle
        float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) + Mathf.Rad2Deg;

        // Rotate the aim triangle around its own center
        aimTriangle.transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.forward);

        // Rotate the aim pivot to face the mouse
        aimPivot.up = aimDirection;

        // Position the aim triangle close to the player
        aimTriangle.transform.position = transform.position + aimDirection * 2f;

       
    

    }


    public Vector3 GetAimDirection()
    {
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;
        aimDirection.z = 0f;
        aimDirection.Normalize();
        return aimDirection;
    }
    
    
}
