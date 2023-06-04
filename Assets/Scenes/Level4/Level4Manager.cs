using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] endingButtons;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject dropCrateButton;
    [SerializeField] private GameObject vanishBlock;
    [SerializeField] private GameObject destroyableBlock;

    [SerializeField] private GameObject reviveText;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Polaroid;

    private bool isDestroyed = false;
    
    


    private bool hasCrateDropped = false;
    void Start()
    {
        vanishBlock.GetComponent<BoxCollider2D>().enabled = true;
    }

 
    void Update()
    {
        if( Player.GetComponent<PlayerController>().isDead == true){
            reviveText.SetActive(true);
        }else{
            reviveText.SetActive(false);
        }
        
        if(!isDestroyed){
            if (endingButtons[0].GetComponent<Button>().isPressed && endingButtons[1].GetComponent<Button>().isPressed && !isDestroyed)
        {
            isDestroyed = true;
            Destroy(door);
            Destroy(endingButtons[0]);
            Destroy(destroyableBlock);
        }
        }
       
        if(dropCrateButton.GetComponent<Button>().isPressed && !hasCrateDropped)
        {
            dropCrate();
            hasCrateDropped = true;
        }
    }


    void dropCrate()
    {
        vanishBlock.GetComponent<BoxCollider2D>().enabled = false;
    }
}
