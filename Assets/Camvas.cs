using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camvas : MonoBehaviour {


    public Text score;
    public Text paused;
    public Text pressenter;
    public Text credits;

    public Text Gameover;

    private int Score;

    
    

    private void Start()
    {
        score.text = "0";
        Score = 0;
    }

    private void Update()
    {
         score.text = Score.ToString(); 
    }
    public void scoreCanvas(int typeOfFood) 
    {
        if (typeOfFood == 1)
        {
            Score += 1;
           
        }
        if(typeOfFood == 2)
        {
            Score += 5;
        }
    }
    public void Paused(bool pausedBool)
    {
        if (pausedBool)
        {
            paused.text = "Game Paused";
        }
        else
        {
            paused.text = "";
        }
    }
    public void gameOver()
    {
        Time.timeScale = 0;
        Gameover.text = "Game Over";
        pressenter.text = "Press ENTER to restart";
    }
    public void restart()
    {
        Time.timeScale = 1;
        Gameover.text = "";
        pressenter.text = "";
    }


}
