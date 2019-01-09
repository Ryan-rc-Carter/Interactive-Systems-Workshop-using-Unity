using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHighScore : MonoBehaviour {

    /// <summary>
    /// This code changes the highscore text to the playerprefs variable Highscore upon opening the game, resetting the highscore or returning to the menu
    /// </summary>

    [SerializeField] //Makes private variables visible inside the unity editor
    private Text highScoreText;


	void Start () {

        ResetHighScore();

    }
	
	
	public void ResetHighScore()

    {

        int tempHighScore = PlayerPrefs.GetInt("Highscore");


        highScoreText.text = "Highscore - " + tempHighScore;
    }
}
