using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotateScript : MonoBehaviour
{
    public Transform aimPivot;
    private Quaternion initialRotation;
    public Vector3 aimDirection;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject gameManager;

    private void Start()
    {
         initialRotation = transform.rotation;
    }

    private void Update()
    {   
        if(gameManager.GetComponent<GameManager>().playerInCannon)
        {
            
        
            GetAimDirection();

            // Calculate the rotation angle
            float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) + Mathf.Rad2Deg;

            // Rotate the aim triangle around its own center
            transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.forward);

            // Rotate the aim pivot to face the mouse
            aimPivot.up = aimDirection;

            // Position the aim triangle close to the player
            transform.position = transform.position + aimDirection * 2f;
        }
        else
        {
            transform.rotation = initialRotation;
        }
    }

    public void UpdateSpriteRotation(Vector3 aimDirection)
    {
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Vector3 GetAimDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;
        aimDirection.z = 0f;
        aimDirection.Normalize();
        return aimDirection;
    }
}
