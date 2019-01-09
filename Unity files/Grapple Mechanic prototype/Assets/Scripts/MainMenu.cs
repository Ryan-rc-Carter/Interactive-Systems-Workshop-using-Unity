using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    //this script saves the high score if it was broken in the last run when the player returns to the main menu
    private int tempScore;
    private int tempHighScore;

    public void OnClick()
    {
        tempScore = PlayerPrefs.GetInt("Score");
        tempHighScore = PlayerPrefs.GetInt("Highscore");


        if(tempScore > tempHighScore)
        {
            PlayerPrefs.SetInt("Highscore", tempScore);


        }

        SceneManager.LoadScene(0);
    }
}

