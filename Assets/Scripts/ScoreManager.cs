using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {
    //variables used to add a score to the score text in UI 
    public int score;
    //Creates a n instance of Score to allow the score to be added when pacdot eaten by pacman
    public static ScoreManager instSc;
    public Text scoreText;
    int pDoctValue = 10;
    //Method to add score when collision between pacman and pacdot is triggered
    public void PacDotScore()
    {
        score += pDoctValue;

        scoreText.text = "Score: " + score;

    }

    private void Awake()
    {
        instSc = this;

    }

}
