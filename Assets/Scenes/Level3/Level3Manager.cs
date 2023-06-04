using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject lever;
    [SerializeField] private GameObject inCannonText;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject POLAROID;



    private bool hasButtonDropped = false;
    void Start()
    {   
        inCannonText.SetActive(false);
        //disable rigidbody
        buttons[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    
    }

    // Update is called once per frame
    void Update()
    {
        //check if all buttons are pressed  
        if (buttons[0].GetComponent<Button>().isPressed && buttons[1].GetComponent<Button>().isPressed)
        {

            Destroy(door);
        }
        if(lever.GetComponent<LeverTrigger>().isActive && !hasButtonDropped)
        {
            dropButton();
            hasButtonDropped = true;
        }

        if(gameManager.GetComponent<GameManager>().playerInCannon==true)
        {
           inCannonText.SetActive(true);
          
        }else{
            inCannonText.SetActive(false);
        }
       
        
        
    }

    void dropButton()
    {

        //enable rigidbody
        buttons[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

}
