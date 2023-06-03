using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5_manager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;

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

       // if(GetComponent<Button>().isPressed){
           //TODO: MUDAR ESTADO DO PERSONAGEM PARA DEAD AF  E UNALIVE
        //}
    }
}
