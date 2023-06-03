using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_manager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(//Button.GetComponent<Button>().isPressed && 
        Lever.GetComponent<LeverTrigger>().isActive){
           Destroy(door);
        }

    }
}
