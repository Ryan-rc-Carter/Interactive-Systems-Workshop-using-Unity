using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighscore : MonoBehaviour {

    /// <summary>
    /// This code resets the playerpref variable "Highscore" and changes the main menu text to represent this
    /// </summary>

    [SerializeField] //Makes private variables visible inside the unity editor
    private Text highScoreText;

    public void OnClick()
    {
        PlayerPrefs.SetInt("Highscore", 0);

        int tempHighScore = PlayerPrefs.GetInt("Highscore");


        highScoreText.text = "Highscore - " + tempHighScore;
    }
}
