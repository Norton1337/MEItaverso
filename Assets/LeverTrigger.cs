using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public bool playerInRange = false;
    public Sprite activatedSprite;
    public Sprite deactivatedSprite;

    public bool isActive = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deactivatedSprite;
        DeactivateLever();
    }
    // Update is called once per frame
    void Update()
    {
         if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player toggled lever");
            if (!isActive)
            {
                ActivateLever();
            }
            else
            {
                DeactivateLever();
            }

        }
    }

    private void ActivateLever()
    {
        isActive = true;
        spriteRenderer.sprite = activatedSprite;
        // Perform lever activation behavior here
        Debug.Log("Lever activated!");

    }

    private void DeactivateLever()
    {

        isActive = false;
        spriteRenderer.sprite = deactivatedSprite;
        // Perform lever deactivation behavior here
        Debug.Log("Lever deactivated!");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


    public bool IsPlayerInRange()
    {
        return playerInRange;
    }
}