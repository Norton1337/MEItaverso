using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool playerInCannon = false;
    private CannonTrigger cannonTrigger;
    private Vector3 originalPlayerPosition;
    private GameObject playerObject;

    private bool playerInCannonRage;
    private float launchForce = 50f;
    public bool playerLaunched = false;
    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            ResetLevel();
        }
    }

     

    public void PlayerEnterCannon(Vector3 cannonPosition){
        if (!playerInCannon)
        {   


            playerInCannon = true;

            // Disable the player's sprite renderer to make it disappear
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponentInChildren<SpriteRenderer>();
            playerSpriteRenderer.enabled = false;

            // Store the original player position
            originalPlayerPosition = playerObject.transform.position;

            // Set the player's position to the cannonTrigger's position
            playerObject.transform.position = cannonPosition;

            // Reset the velocity of the player
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = Vector2.zero;
        }
       
    }
    
    public void PlayerExitCannon(){
        if (playerInCannon)
        {
            //get aimDirection from player
            Vector3 aimDirection = playerObject.GetComponent<PlayerController>().GetAimDirection();
            Debug.Log("Player exited the cannon!");
            playerInCannon = false;

            // Enable the player's sprite renderer to make it visible again
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponentInChildren<SpriteRenderer>();
            playerSpriteRenderer.enabled = true;

            

            // Add force to the player rigidbody to launch them in the aim direction
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(aimDirection.x * launchForce, aimDirection.y * launchForce);


            playerLaunched = true;


        }
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
