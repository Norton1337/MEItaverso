using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level6_management : MonoBehaviour
{
    public float levelTime = 10f;
    private float timeLeft;
    private bool isGameOver = false;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){
            timeLeft -= Time.deltaTime;

            timerText.text = timeLeft.ToString("0");
            if(timeLeft <= 0){
                timerText.text = string.Format("{0:00}:{00:00}");
                GameOver();
                
            }

            UpdateTimer();            
        }
    }

    private void GameOver(){
        isGameOver = true;
        timeLeft = 0;
        timerText.text = "00:00";
        GameOver();
    }

    private void UpdateTimer(){

        if(timeLeft<=0){
            timerText.text = "00:00";
        }
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        // Update the timer text display in the UI
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
