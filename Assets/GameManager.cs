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
        playerInCannonRage = cannonTrigger.IsPlayerInRange();
        if (Input.GetMouseButtonDown(0))
        {
            PlayerInteractCannon();
        }
    }

     

    public void PlayerInteractCannon(){
        if (!playerInCannon && playerInCannonRage)
        {   

            playerInCannon = true;

            // Disable the player's sprite renderer to make it disappear
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            playerSpriteRenderer.enabled = false;

            // Store the original player position
            originalPlayerPosition = playerObject.transform.position;

            // Set the camera's position to the cannon's position
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
            
        }
        else if (playerInCannon)
        {
            Debug.Log("Player exited the cannon!");
            playerInCannon = false;

            // Enable the player's sprite renderer to make it visible again
            SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
            playerSpriteRenderer.enabled = true;

            // Reset the player's position to the stored original position
            playerObject.transform.position = originalPlayerPosition;

            // Reset the camera's position to the original position or any desired position
            mainCamera.transform.position = new Vector3(originalPlayerPosition.x, originalPlayerPosition.y, mainCamera.transform.position.z);
        }
    }
    

}
