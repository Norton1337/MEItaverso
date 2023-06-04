using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5_manager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Lever.GetComponent<LeverTrigger>().isActive){
           Destroy(door);
        }

        if(button.GetComponent<Button>().isPressed){
           player.GetComponent<PlayerController>().isDead = true;
           player.GetComponent<PlayerController>().checkDead();
        }
    }
}
