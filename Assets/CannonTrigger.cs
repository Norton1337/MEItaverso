using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
    public bool playerInRange = false;
    private bool inCannon = false;
    private void OnMouseDown()
    {
        inCannon = GameManager.Instance.playerInCannon;
        if (playerInRange && !inCannon)
        {   
            Debug.Log("Player entered the cannon!");
            GameManager.Instance.PlayerInteractCannon();
        }
        

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

