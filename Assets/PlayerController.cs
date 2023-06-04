using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform aimPivot;
    private Quaternion initialRotation;
    public Vector3 aimDirection;
    public float speed = 10f;
    public float jumpForce = 20f;
    public GameObject aimTriangle;
    private float Move;
   
    private Rigidbody2D rb;
    public bool inCannon;
    public bool isLaunched = false;

    public int bounceCount = 0;
    public int maxBounceCount = 3;
    public float bounceSpeed = 15f;
    public float bounceSpeedIncrement = 10f;

    public bool isWalking;
    public bool isWalkingLeft;
    
    public bool isDead = false;
    public bool deadBodyActive = false;
    public GameObject ghostSprite;
    public GameObject spawnedSprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialRotation = aimTriangle.transform.rotation;
    }

    void Update()
    {
        checkDead();
        isLaunched = GameManager.Instance.playerLaunched;
        // get is player in cannon from GameManager
        inCannon = GameManager.Instance.playerInCannon;
        

        if(!inCannon && !isLaunched)
        {
            
            Move = Input.GetAxis("Horizontal");
           
            if (Move != 0)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
            if (Move < 0)
            {
                isWalkingLeft = true;
            }
            else
            {
                isWalkingLeft = false;
            }
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

            isDead = true;
                
        }
        

        GetAimDirection();        // Calculate the rotation angle
        // Calculate the rotation angle
        float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) + Mathf.Rad2Deg;

        // Rotate the aim triangle around its own center
        aimTriangle.transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.forward);

        // Rotate the aim pivot to face the mouse
        aimPivot.up = aimDirection;

        // Position the aim triangle close to the player
        aimTriangle.transform.position = transform.position + aimDirection * 2f;

       if (isDead && Input.GetKeyDown(KeyCode.X) 
       && spawnedSprite.GetComponent<Unalive>().playerInRange) {
           PlayerUnUnAlive();
        }
    }


 
    
    private void OnCollisionEnter2D(Collision2D collision) {
        

        if(!isDead){
            if (collision.gameObject.CompareTag("Trampoline")) {
            //Only jumps if player is touching the top of the trampoline
            Vector2 contactNormal = collision.GetContact(0).normal;

            if (contactNormal.y > 0.9f) {
                if (bounceCount < maxBounceCount) {
                    float bounce = bounceSpeed + (bounceCount * bounceSpeedIncrement);
                    rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                    // isJumping = true;

                    bounceCount++;
                    if (bounceCount == maxBounceCount) {
                        isDead = true;  
                    }
                }
            }
            } else {
                bounceCount = 0;
            }
        }
        

        
        
    }

    public void checkDead() {
        if (isDead && !deadBodyActive) {
           
            if(Mathf.Abs(rb.velocity.x) < 0.001f && Mathf.Abs(rb.velocity.y) < 0.001f){
                Vector3 spawnPosition = transform.position;
                spawnedSprite = Instantiate(ghostSprite, spawnPosition, Quaternion.identity);
                spawnedSprite.transform.Rotate(0f,0f,90f);
                deadBodyActive = true;
            }
            
        }
    }
        
    public Vector3 GetAimDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;
        aimDirection.z = 0f;
        aimDirection.Normalize();
        return aimDirection;
    }

    public void PlayerUnUnAlive() {
        Destroy(spawnedSprite);
        bounceCount = 0;
        isDead = !isDead;
        deadBodyActive = !deadBodyActive;

    }

    public bool isWalkingRight() {
        return !isWalkingLeft;
    }

    public bool getIsWalking() {
        return isWalking;
    }
    
}
