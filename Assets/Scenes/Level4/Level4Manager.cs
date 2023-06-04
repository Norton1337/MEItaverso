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

    private bool hasCrateDropped = false;
    void Start()
    {
        vanishBlock.GetComponent<BoxCollider2D>().enabled = true;
    }

 
    void Update()
    {
        if (endingButtons[0].GetComponent<Button>().isPressed && endingButtons[1].GetComponent<Button>().isPressed)
        {
            Destroy(door);
            Destroy(endingButtons[0]);
            Destroy(destroyableBlock);
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
