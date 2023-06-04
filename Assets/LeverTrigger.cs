using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public bool playerInRange = false;
    public bool isActive = false;

    void Start()
    {

        DeactivateLever();
    }
    // Update is called once per frame
    void Update()
    {
         if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
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


    }

    private void DeactivateLever()
    {

        isActive = false;


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