using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level6_management : MonoBehaviour
{
    public float levelTime = 10f;
    private float timeLeft;
    private float gameOverTimer;
    private bool isGameOver = false;
    public TextMeshProUGUI timerText;
    private bool handlingGameOver = false;


    [SerializeField] private GameObject endingScreen;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject door;

    private Vector2 startingPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPlayerPos = player.transform.position;
        endingScreen.SetActive(false);
        timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
    {

        
        if(!isGameOver && !handlingGameOver){
            if(timeLeft <= 0.01f){
                int minutes = Mathf.FloorToInt(timeLeft / 60);
                int seconds = Mathf.FloorToInt(timeLeft % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                GameOver();
                
            }else{
                timeLeft -= Time.deltaTime;
                //timeleft as float
                
                timerText.text = timeLeft.ToString("0");
                

                UpdateTimer();     
            }
                  
        }
        if(handlingGameOver){
            gameOverTimer += Time.deltaTime;
            if(gameOverTimer >= 3f){
                handlingGameOver = false;
                gameOverTimer = 0;
                isGameOver = false;
                //lower door opacity
                Color tempColor = door.GetComponent<SpriteRenderer>().color;
                tempColor.a = tempColor.a - 0.05f;
                door.GetComponent<SpriteRenderer>().color = tempColor;

                ResetPlayer();
                Start();
            }
            
        }
    }

    private void GameOver(){
        isGameOver = true;
        timeLeft = 0;
        timerText.text = "00:00";
        handlingGameOver = true;
        HandleGameOver();
    }

    private void UpdateTimer(){

        if(timeLeft<=0.01f){
            timerText.text = "00:00";
        }
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        // Update the timer text display in the UI
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HandleGameOver(){
        //bring endingScreen to front
        endingScreen.SetActive(true);
    }

    public void ResetPlayer(){
        player.GetComponent<PlayerController>().PlayerUnUnAlive();
        player.transform.position = startingPlayerPos;
    }
}
