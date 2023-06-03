using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_management : MonoBehaviour
{
     [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject GameOverScreen;

    public int ctdr = 0;



    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
