using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool playerInCannon = false;
    private CannonTrigger cannonTrigger;
    private Vector3 originalPlayerPosition;
    private GameObject playerObject;
    private Camera mainCamera;
    private bool playerInCannonRage;
    private float launchForce = 50f;
    public bool playerLaunched = false;
    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        mainCamera = playerObject.GetComponentInChildren<Camera>();
        cannonTrigger = GetComponent<CannonTrigger>();
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && playerInCannon)
        {

            PlayerExitCannon();
        }
    }

     

    public void PlayerEnterCannon(Vector3 cannonPosition){
        if (!playerInCannon)
        {   
            Debug.Log("Player entered the cannon! Game Manager");

            playerInCannon = true;

            // Disable the player's sprite renderer to make it disappear
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            playerSpriteRenderer.enabled = false;

            // Store the original player position
            originalPlayerPosition = playerObject.transform.position;

            // Set the player's position to the cannonTrigger's position
            playerObject.transform.position = cannonPosition;

            // Set the camera's position to the cannon's position
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
            
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = Vector2.zero; 
        }
       
    }
    
    public void PlayerExitCannon(){
        if (playerInCannon)
        {
            //get aimDirection from player
            Vector3 aimDirection = playerObject.GetComponent<Movement>().GetAimDirection();
            Debug.Log("Player exited the cannon!");
            playerInCannon = false;

            // Enable the player's sprite renderer to make it visible again
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            playerSpriteRenderer.enabled = true;


            // Reset the camera's position to the original position or any desired position
            mainCamera.transform.position = new Vector3(originalPlayerPosition.x, originalPlayerPosition.y, mainCamera.transform.position.z);

            

            // Add force to the player rigidbody to launch them in the aim direction
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(aimDirection.x * launchForce, aimDirection.y * launchForce);
            Debug.Log("aimDirection: " + aimDirection);
            Debug.Log("velocity: " + playerRigidbody.velocity);

            playerLaunched = true;


        }
    }

}
