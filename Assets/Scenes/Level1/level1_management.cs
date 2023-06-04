using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_management : MonoBehaviour
{
     [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject Parede;
    [SerializeField] private GameObject Player;

    public int ctdr = 0;
    public float ctdrHeight = 0;
    public float maxHeight = 3f;



    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {

        if (Lever.GetComponent<LeverTrigger>().isActive && ctdrHeight < maxHeight) {
            Parede.transform.Translate(0,0.01f,0);
            ctdrHeight += 0.01f;
        }

        if(Button.GetComponent<Button>().isPressed == true && ctdr < 1){
            GameOverScreen.SetActive(true);
            StartCoroutine(PauseGame());
            Debug.Log("Game Resumed After 3 Seconds End Screen");
            ctdr++;
        }

        if( Button.GetComponent<Button>().isPressed && Lever.GetComponent<LeverTrigger>().isActive
        ){
            Debug.Log("Button is pressed and lever is active");
           Destroy(door);
        }
    }

    private IEnumerator PauseGame()
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1f;
        GameOverScreen.SetActive(false);
    
        Player.GetComponent<PlayerController>().isDead = true;
        Player.GetComponent<PlayerController>().checkDead();

    }
}
