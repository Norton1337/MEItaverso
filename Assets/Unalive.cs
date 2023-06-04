using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unalive : MonoBehaviour
{

    public bool playerInRange = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && 
        collision.gameObject.GetComponent<PlayerController>().isDead) {
            
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerInRange = false;
        }
    }

}
