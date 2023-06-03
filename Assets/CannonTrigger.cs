using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
    public bool playerInRange = false;
    private bool inCannon = false;
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !inCannon)
        {
            Debug.Log("Player entered the cannon!");
            //get trigger position
            
            GameManager.Instance.PlayerEnterCannon(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && 
        !collision.gameObject.GetComponent<PlayerController>().isDead)
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

