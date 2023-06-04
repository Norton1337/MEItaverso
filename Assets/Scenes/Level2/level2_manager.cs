using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_manager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject DropablePlatform;

    public float ctdrDistance = 0;
    public float maxDistance = 15;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.GetComponent<Button>().isPressed && 
        Lever.GetComponent<LeverTrigger>().isActive){
           Destroy(door);
        }

        //TODO: METER A PLATAFORMA A CAIR QUANDO O BOTAO FOR PRESSIONADO
        if(Button.GetComponent<Button>().isPressed && ctdrDistance < maxDistance){
            DropablePlatform.transform.Translate(-0.01f,0,0);
            ctdrDistance += 0.01f;
        } else if (ctdrDistance >= maxDistance) {
            Debug.Log("test");
        }
    }
}
