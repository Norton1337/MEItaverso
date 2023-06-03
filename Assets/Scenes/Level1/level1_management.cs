using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_management : MonoBehaviour
{
     [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject GameOverScreen;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.GetComponent<Button>().isPressed == true){
            //TODO: FAKE GAME-OVER
            GameOverScreen.SetActive(true);

        }

        if( Button.GetComponent<Button>().isPressed && Lever.GetComponent<LeverTrigger>().isActive
        ){
            Debug.Log("Button is pressed and lever is active");
           Destroy(door);
        }
    }
}
