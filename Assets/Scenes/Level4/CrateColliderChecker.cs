using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateColliderChecker : MonoBehaviour
{
    [SerializeField] private GameObject vanishBlock;
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("BecomeReal"))
        {
            Debug.Log("BecomeReal");
            vanishBlock.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
