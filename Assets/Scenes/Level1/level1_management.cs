using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level1_management : MonoBehaviour
{
     [SerializeField] private GameObject door;
    [SerializeField] private GameObject Lever;
    [SerializeField] private GameObject Button;

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject Parede;
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Only_Alive_Button;
    [SerializeField] private GameObject Only_Alive_BoxDrag;
    [SerializeField] private GameObject Dead_revive;

    [SerializeField] private GameObject Polaroid;    

    

    public int ctdr = 0;
    public float ctdrHeight = 0;
    public float maxHeight = 3f;



    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);   
        Canvas.SetActive(true);
        Dead_revive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if( Player.GetComponent<PlayerController>().isDead == true){
            Only_Alive_Button.SetActive(false);
            Only_Alive_BoxDrag.SetActive(false);
            Dead_revive.SetActive(true);

        }else{
            Dead_revive.SetActive(false);
            Only_Alive_Button.SetActive(true);
            Only_Alive_BoxDrag.SetActive(true);
        }

        if (Lever.GetComponent<LeverTrigger>().isActive && ctdrHeight < maxHeight) {
            Parede.transform.Translate(0,0.01f,0);
            ctdrHeight += 0.01f;
        }

        if(Button.GetComponent<Button>().isPressed == true && ctdr < 1){
            GameOverScreen.SetActive(true);
            StartCoroutine(PauseGame());
            ctdr++;
        }

        if( Button.GetComponent<Button>().isPressed && Lever.GetComponent<LeverTrigger>().isActive
        ){
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
