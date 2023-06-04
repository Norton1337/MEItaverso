using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderChecker : MonoBehaviour
{
    [SerializeField] private GameObject Level5Manager;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
           Level5Manager.GetComponent<level5_manager>().ResetPlayer();
        }
    }
}
