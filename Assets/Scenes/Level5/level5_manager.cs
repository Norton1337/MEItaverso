using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5_manager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;

    private Vector2 startingPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPlayerPos = player.transform.position;
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

    public void ResetPlayer(){
        player.transform.position = startingPlayerPos;
    }
}
